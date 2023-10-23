using System.Security.Claims;
using DigitalDungeon.Data;
using DigitalDungeon.Models;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    //[Authorize(Roles = "Admin")]
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
    //[Authorize]
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
        return Ok(preferences);
    }

    [HttpGet("{id}")]
    //[Authorize]
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
    //[Authorize(Roles = "Admin")]
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
    //[Authorize]
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
        .Where(game => userGenreIds.Contains(game.GenreId) && userCategoryIds.Contains(game.CategoryId))
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

}
