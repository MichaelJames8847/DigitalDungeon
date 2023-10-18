using System.ComponentModel.DataAnnotations;

namespace DigitalDungeon.Models;
public class UserFavoriteGame
{
    public int Id { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    [Required]
    public int GameId { get; set; }
    public Game Game { get; set; }
}