using System.ComponentModel.DataAnnotations;

namespace DigitalDungeon.Models;
public class UserGenre
{
    public int Id { get; set; }
    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public List<Game> Games { get; set; }
}