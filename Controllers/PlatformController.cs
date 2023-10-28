using DigitalDungeon.Data;
using DigitalDungeon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class PlatformController : ControllerBase
{
    private DigitalDungeonDbContext _dbContext;

    public PlatformController(DigitalDungeonDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]

    public IActionResult Get()
    {
        return Ok(_dbContext.Platforms
             .ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPlatformById(int id)
    {
        Platform platform = _dbContext
        .Platforms
        .Include(p => p.PlatformGames)
        .ThenInclude(pg => pg.Game)
        .ThenInclude(g => g.Genre)
        .Include(p => p.PlatformGames)
        .ThenInclude(pg => pg.Game)
        .ThenInclude(g => g.Category)
        .SingleOrDefault(p => p.Id == id);

        if (platform == null)
        {
            return NotFound();
        }

        return Ok(platform);
    }
}