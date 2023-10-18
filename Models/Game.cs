using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalDungeon.Models;
public class Game 
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [JsonPropertyName("name")]
    public string Title { get; set;}
    [DataType(DataType.Url)]
    [JsonPropertyName("background_image")]
    public string CoverImage { get; set;}
    [JsonPropertyName("description")]
    public string Description { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [JsonPropertyName("released")]
    public DateTime? ReleaseDate { get; set; }
    public string Developer { get; set; }
    public bool? AdminApproval { get; set; }
    public List<UserGenre> UserGenres { get; set; }
    public List<UserCategory> UserCategories { get; set; }
    public List<UserFavoriteGame> UserFavoriteGames { get; set; }
    public List<UserProfile> UserProfiles { get; set; }
    [JsonPropertyName("platforms")]
    public List<Platform> Platforms { get; set; }
}