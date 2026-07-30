namespace CarWorkshop.MVC.Models;

public class Notifaction
{
    public Notifaction(string type, string message)
    {
        Type = type;
        Message = message;
    }
    public string Type { get; set; }
    public string Message { get; set; }
}