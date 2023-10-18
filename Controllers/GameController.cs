using DigitalDungeon.Data;
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
    //[Authorize]

    public IActionResult GetGames()
    {
        return Ok(_dbContext.Games.ToList());
    }
}