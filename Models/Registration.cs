namespace DigitalDungeon.Models;

public class Registration
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Category> Categories { get; set; }

}