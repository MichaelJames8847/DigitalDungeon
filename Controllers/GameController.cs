using System.Security.Claims;
using DigitalDungeon.Data;
using DigitalDungeon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private DigitalDungeonDbContext _dbContext;
    public GameController(DigitalDungeonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]

    public IActionResult GetGames()
    {
        return Ok(_dbContext.Games.Where(g => g.AdminApproval == true).ToList());
    }

    [HttpGet("{id}")]
    [Authorize]

    public IActionResult GetGameById(int id)
    {
        Game game = _dbContext
        .Games
        .Include(g => g.Genre)
        .Include(g => g.Category)
        .Include(g => g.PlatformGames)
        .ThenInclude(pg => pg.Platform)
        .SingleOrDefault(g => g.Id == id);

        if (game == null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpGet("search/{query}")]
    [Authorize]
    public IActionResult SearchGames(string query)
    {
        var games = _dbContext.Games
            .Where(g => g.Title.Contains(query))
            .Include(g => g.Genre)
            .Include(g => g.Category)
            .Include(g => g.PlatformGames)
            .ThenInclude(pg => pg.Platform)
            .ToList();

        return Ok(games);
    }

    [HttpPost("suggest")]
    [Authorize]
    public IActionResult SuggestGame([FromBody] GameSuggestionDTO gameSuggestionDTO)
    {
        if (gameSuggestionDTO == null || string.IsNullOrWhiteSpace(gameSuggestionDTO.Name))
        {
            return BadRequest("Title is required.");
        }

        // Set only the title and AdminApproval properties
        Game game = new Game
        {
            Title = gameSuggestionDTO.Name,
            AdminApproval = false,
            CategoryId = 1, // Setting to 1 as a placeholder to avoid foreign key restraint
            GenreId = 1 // Setting to 1 as a placeholder
        };

        _dbContext.Games.Add(game);
        _dbContext.SaveChanges();

        return Ok(new { Message = "Your suggestion is pending approval. You will be notified once the admins review it." });
    }

    [HttpGet("pending-suggestions")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetPendingGameSuggestions()
    {
        var games = _dbContext.Games.Where(g => g.AdminApproval == false).ToList();
        return Ok(games);
    }

    [HttpPost("approve/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult ApproveGame(int id)
    {
        var game = _dbContext.Games.Find(id);
        if (game == null)
        {
            return NotFound();
        }
        game.AdminApproval = true;
        _dbContext.SaveChanges();
        return Ok(new { Message = "Game approved successfully!" });
    }

    [HttpPost("deny/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DenyGame(int id)
    {
        var game = _dbContext.Games.Find(id);
        if (game == null)
        {
            return NotFound();
        }
        _dbContext.Games.Remove(game);
        _dbContext.SaveChanges();
        return Ok(new { Message = "Game denied and removed successfully!" });
    }

    [HttpPut("update/{gameId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateGame(int gameId, [FromBody] GameUpdateDTO gameUpdateDTO)
    {
        var game = _dbContext.Games.Find(gameId);
        if (game == null)
        {
            return NotFound();
        }

        game.CoverImage = gameUpdateDTO.CoverImage;
        game.Description = gameUpdateDTO.Description;
        game.ReleaseDate = gameUpdateDTO.ReleaseDate;
        game.Developer = gameUpdateDTO.Developer;
        game.GenreId = gameUpdateDTO.GenreId;
        game.CategoryId = gameUpdateDTO.CategoryId;
        game.AdminApproval = true;

        if (gameUpdateDTO.PlatformIds != null)
        {
            game.Platforms.Clear();

            foreach (var platformId in gameUpdateDTO.PlatformIds)
            {
                var platform = _dbContext.Platforms.Find(platformId);
                if (platform != null)
                {
                    game.Platforms.Add(platform);
                }
            }
        }
        
        _dbContext.Games.Update(game);
        _dbContext.SaveChanges();

        return Ok(game);
    }

    [HttpDelete("{gameId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteGame(int gameId)
    {
        Game game = _dbContext.Games.SingleOrDefault(g => g.Id == gameId);
        if (game == null)
        {
            return NotFound();
        }
        else if (gameId != game.Id)
        {
            return BadRequest();
        }

        _dbContext.Games.Remove(game);
        _dbContext.SaveChanges();
        return NoContent();
    }
}