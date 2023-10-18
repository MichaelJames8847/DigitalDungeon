using System.ComponentModel.DataAnnotations;

namespace DigitalDungeon.Models;
public class Genre
{
    public int Id { get; set; }
    [Required]
    public string GenreName { get; set; }
    public List<UserGenre> UserGenres { get; set; }
    public List<UserProfile> UserProfiles { get; set; }
    public List<Game> Games { get; set; }
}