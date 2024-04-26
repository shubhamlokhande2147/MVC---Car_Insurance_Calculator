using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CIC_System.Models;

namespace CIC_System.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

       public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username == "Admin" && password == "Admin")
            {
                // Redirect to dashboard or any other page after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Invalid login, show error message
                ViewBag.Error = "Invalid username or password";
                Console.WriteLine("Invalid Password");
                return View();
            }
        }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
