namespace DigitalDungeon.Models;
public class PlatformGame
{
    public int Id { get; set; }
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
}