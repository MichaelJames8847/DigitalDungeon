using System.Security.Claims;
using DigitalDungeon.Data;
using DigitalDungeon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class UserProfileController : ControllerBase
{
    private DigitalDungeonDbContext _dbContext;

    public UserProfileController(DigitalDungeonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpPost("preferences")]
    [Authorize]
    public IActionResult SetPreferences(Preferences preferences)
    {
        var genres = preferences.Genres;
        var categories = preferences.Categories;

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == userId);

        if (profile == null)
        {
            return NotFound();
        }

        foreach (var genre in genres)
        {
            _dbContext.UserGenres.Add(new UserGenre { GenreId = genre.Id, UserProfileId = profile.Id });

        }

        foreach (var category in categories)
        {
            _dbContext.UserCategories.Add(new UserCategory { CategoryId = category.Id, UserProfileId = profile.Id });
        }


        var updatedProfile = _dbContext.UserProfiles
            .Include(up => up.UserGenres)
            .Include(up => up.UserCategories)
            .SingleOrDefault(up => up.IdentityUserId == userId);

        _dbContext.SaveChanges();
        return Ok(updatedProfile);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        UserProfile userProfile = _dbContext
            .UserProfiles
            .Include(up => up.UserGenres)
            .ThenInclude(ug => ug.Genre)
            .ThenInclude(g => g.Games)
            .Include(up => up.UserCategories)
            .ThenInclude(uc => uc.Category)
            .ThenInclude(uc => uc.Games)
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteUser(int id)
    {
        UserProfile userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);
        if (userProfile == null)
        {
            return NotFound();
        }
        else if (id != userProfile.Id)
        {
            return BadRequest();
        }

        _dbContext.UserProfiles.Remove(userProfile);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpGet("games")]
    [Authorize]
    public IActionResult GetSuggestedGames()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userProfile = _dbContext.UserProfiles
            .Include(up => up.UserGenres)
            .ThenInclude(ug => ug.Genre)
            .Include(up => up.UserCategories)
            .ThenInclude(uc => uc.Category)
            .SingleOrDefault(up => up.IdentityUserId == userId);

        if (userProfile == null)
        {
            return NotFound();
        }

        var userGenreIds = userProfile.UserGenres.Select(ug => ug.GenreId).ToList();
        var userCategoryIds = userProfile.UserCategories.Select(uc => uc.CategoryId).ToList();

        var suggestedGames = _dbContext.Games
        .Include(game => game.Genre)
        .Include(game => game.Category)
        .Where(game => userGenreIds.Contains(game.GenreId)
        && userCategoryIds.Contains(game.CategoryId))
        .Select(game => new
        {
            game.Id,
            game.Title,
            game.CoverImage,
            game.Description,
            game.ReleaseDate,
            Genre = game.Genre.GenreName,
            Category = game.Category.CategoryName,
            game.Developer
        })
       .ToList();

        if (!suggestedGames.Any())
        {
            return Ok("No matching games found");
        }

        return Ok(suggestedGames);
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("games/{gameId}/suggestions")]
    [Authorize]
    public IActionResult RemoveFromSuggestions(RemoveSuggestedGame removeSuggestedGame)
    {
        int gameId = removeSuggestedGame.GameId;

        var game = _dbContext.Games.Find(gameId);
        if (game == null)
        {
            return NotFound();
        }

        _dbContext.Games.Update(game);
        _dbContext.SaveChanges();

        return Ok(game);
    }


    [HttpPut("preferences")]
    [Authorize]
    public IActionResult UpdatePreferences(Preferences preferences)
    {
        var genres = preferences.Genres;
        var categories = preferences.Categories;

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == userId);

        if (profile == null)
        {
            return NotFound();
        }

        foreach (var genre in genres)
        {
            _dbContext.UserGenres.Add(new UserGenre { GenreId = genre.Id, UserProfileId = profile.Id });
        }

        foreach (var category in categories)
        {
            _dbContext.UserCategories.Add(new UserCategory { CategoryId = category.Id, UserProfileId = profile.Id });
        }

        var updatedProfile = _dbContext.UserProfiles
            .Include(up => up.UserGenres)
            .Include(up => up.UserCategories)
            .SingleOrDefault(up => up.IdentityUserId == userId);

        _dbContext.SaveChanges();
        return Ok(updatedProfile);
    }

    [HttpGet("preferences")]
    [Authorize]
    public IActionResult GetPreferences()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles
            .Include(up => up.UserGenres)
            .ThenInclude(ug => ug.Genre)
            .Include(up => up.UserCategories)
            .ThenInclude(uc => uc.Category)
            .SingleOrDefault(up => up.IdentityUserId == userId);

        if (profile == null)
        {
            return NotFound();
        }

        var userGenres = profile.UserGenres.Select(ug => ug.Genre).ToList();
        var userCategories = profile.UserCategories.Select(uc => uc.Category).ToList();

        var preferences = new Preferences
        {
            Genres = userGenres,
            Categories = userCategories
        };

        return Ok(preferences);
    }

    [HttpGet("{id}/purchase-links")]
    [Authorize]
    public IActionResult GetPurchaseLinksForGames()
    {
        var purchaseLinks = new PurchaseLinkDTO
        {
            PC = "https://store.steampowered.com/",
            Xbox = "https://www.dkoldies.com/original-xbox-games/",
            Xbox360 = "https://marketplace.xbox.com/en-US/games/Xbox360Games",
            XboxOne = "https://www.amazon.com/Xbox-One-Games/b?ie=UTF8&node=6469296011",
            XboxSeriesX = "https://www.amazon.com/s?k=games+for+xbox+series+x&hvadid=657225112929&hvdev=c&hvlocphy=9012700&hvnetw=g&hvqmt=e&hvrand=7979474318198072207&hvtargid=kwd-851440928342&hydadcr=15512_13657504&tag=googhydr-20&ref=pd_sl_9985ndmwfw_e",
            Playstation = "https://www.dkoldies.com/ps1-games/",
            Playstation2 = "https://www.dkoldies.com/PS2-games/?gclid=Cj0KCQjwqP2pBhDMARIsAJQ0CzpP8FRfgbL9yIh0p3OMnk5IuKQfl8X4eElNkCM19-kTMHt45EfybWAaAnJGEALw_wcB",
            Playstation3 = "https://www.amazon.com/s?k=playstation+3+games+for+sale&hvadid=557592300191&hvdev=c&hvlocphy=9012700&hvnetw=g&hvqmt=e&hvrand=10944284089934317497&hvtargid=kwd-297913046063&hydadcr=18919_13357695&tag=googhydr-20&ref=pd_sl_865rvb8mdy_e",
            Playstation4 = "https://store.playstation.com/en-us/category/85448d87-aa7b-4318-9997-7d25f4d275a4/1",
            Playstation5 = "https://store.playstation.com/en-us/category/d71e8e6d-0940-4e03-bd02-404fc7d31a31/1",
            NintendoSwitch = "https://www.nintendo.com/sg/games/switch/index.html",
            WiiU = "https://www.amazon.com/Wii-U-Games/s?k=Wii+U+Games",
            SNES = "https://www.dkoldies.com/snes-games/",
            SegaGenesis = "https://www.dkoldies.com/genesis/",
            Nintendo64 = "https://www.dkoldies.com/nintendo-64/?gclid=Cj0KCQjwqP2pBhDMARIsAJQ0CzrvRFmEBPsIDrfuxiHt8DfI59CsDc9eNmFOLdTAZUXpM6_Z1ZKb8rIaAiRyEALw_wcB",
            Mobile = "https://www.amazon.com/mobile-games/s?k=mobile+games",
            Gamecube = "https://www.dkoldies.com/gamecube/?gclid=Cj0KCQjwqP2pBhDMARIsAJQ0CzpaLlZu7fpW1x1sdjzyO8V-baj9damVDIbUwChAQvdOQ_BMqP6KSsUaAia0EALw_wcB",
            PSP = "https://www.dkoldies.com/psp-games/",
            Dreamcast = "https://www.amazon.com/Games-Sega-Dreamcast-Systems/b?ie=UTF8&node=1065996",
            SegaSaturn = "https://www.amazon.com/Sega-Saturn-Games/b?ie=UTF8&node=12508641",
            GameBoyAdvance = "https://www.dkoldies.com/game-boy-advance-games/"
        };

        return Ok(purchaseLinks);
    }
}
