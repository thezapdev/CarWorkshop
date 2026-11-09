using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarWorkshop.MVC.Extensions;

public static class ControllerExtensions
{
    public static void SetNotification(this Controller controller, string type, string message)
    {
        var notifaction = new Notification(type, message);
        controller.TempData["Notification"] = JsonConvert.SerializeObject(notifaction);
    }
}