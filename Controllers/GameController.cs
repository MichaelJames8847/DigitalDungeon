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
    private GameApiService _gameApiService;

    public GameController(DigitalDungeonDbContext context, GameApiService gameApiService)
    {
        _dbContext = context;
        _gameApiService = gameApiService;
    }

    [HttpGet]
    [Authorize]

    public IActionResult GetGames()
    {
        return Ok(_dbContext.Games.ToList());
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

}