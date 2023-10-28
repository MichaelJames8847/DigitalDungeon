using DigitalDungeon.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// controller for genres from database
[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private DigitalDungeonDbContext _dbContext;

    public GenreController(DigitalDungeonDbContext context)
    {
        _dbContext = context;
    }

    // get all genres from database
    [HttpGet]
    [Authorize]

    public IActionResult GetGenres()
    {
        return Ok(_dbContext.Genres.ToList());
    }

    
}