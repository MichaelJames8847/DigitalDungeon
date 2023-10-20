using DigitalDungeon.Data;
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
    //[Authorize]

    public IActionResult Get()
    {
        return Ok(_dbContext.Platforms
            .Include(p => p.PlatformGames)
            .ThenInclude(pg => pg.Game)
             .ToList());
    }
}