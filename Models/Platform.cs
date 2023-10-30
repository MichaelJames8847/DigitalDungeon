using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalDungeon.Models;
public class Platform
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int GamesInCatalog { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseYear { get; set; }
    public DateTime? EndYear { get; set; }
    public List<Game> Games { get; set; }
    public List<UserFavoriteGame> UserFavoriteGames { get; set; }
    public List<PlatformGame> PlatformGames { get; set; }
    
}