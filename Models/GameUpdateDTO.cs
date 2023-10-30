using System.Text.Json.Serialization;
using DigitalDungeon.Models;

public class GameUpdateDTO
{
    [JsonPropertyName("background_image")]
    public string CoverImage { get; set; }
    public string Description { get; set; }
    [JsonPropertyName("released")]
    public DateTime? ReleaseDate { get; set; }
    public string Developer { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}