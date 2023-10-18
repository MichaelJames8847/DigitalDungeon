namespace DigitalDungeon.Models;
public class UserCategory
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public List<Game> Games { get; set; }
}