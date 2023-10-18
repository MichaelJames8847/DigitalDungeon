using System.ComponentModel.DataAnnotations;

namespace DigitalDungeon.Models;
public class Category
{
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
    public List<Game> Games { get; set; }
    public List<UserCategory> UserCategories { get; set; }
}