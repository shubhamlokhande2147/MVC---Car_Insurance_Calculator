using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CIC_System.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using DAL;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CIC_System.Controllers;

public class VehicleController : Controller
{
    private readonly ILogger<VehicleController> _logger;

    public VehicleController(ILogger<VehicleController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
   
    //Vehile_Registration method
    public IActionResult Vehicle_Registration()
    {
        return View();
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
