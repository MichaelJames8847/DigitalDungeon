using DigitalDungeon.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// controller for categories from database
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private DigitalDungeonDbContext _dbContext;

    public CategoryController(DigitalDungeonDbContext context)
    {
        _dbContext = context;
    }

    // get all categories from database
    [HttpGet]
    //[Authorize]

    public IActionResult GetCategories()
    {
        return Ok(_dbContext.Categories.ToList());
    }
}