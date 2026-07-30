using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe" },
            new Person { FirstName = "Jane", LastName = "Smith" },
            new Person { FirstName = "Alice", LastName = "Johnson" }
        };
        
        return View(model);
    }
    public IActionResult About()
    {
        var model = new List<AboutModel>
        {
            new AboutModel
            {
                Title = "About Us",
                Description = "We are a car workshop dedicated to providing high-quality services.",
                Tags = new[] { "Car", "Workshop", "Services" }
            },
            new AboutModel
            {
                Title = "Our Mission",
                Description = "To deliver exceptional automotive repair and maintenance services.",
                Tags = new[] { "Mission", "Automotive", "Repair" }
            },
            new AboutModel
            {
                Title = "Our Team",
                Description = "Meet our skilled team of mechanics and technicians.",
                Tags = new[] { "Team", "Mechanics", "Technicians" }
            }
        };
        
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
