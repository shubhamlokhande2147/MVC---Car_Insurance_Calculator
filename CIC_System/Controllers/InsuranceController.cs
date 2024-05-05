using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CIC_System.Models;
using Models;
using DAL;

namespace CIC_System.Controllers;

public class InsuranceController : Controller
{
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(ILogger<InsuranceController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
  
    //---------------------------------------------

                public IActionResult Edit_Factors(int id)
                {
                    id = 1;
                    Factors factors = InsuranceDBManager.GetFactorsById(id);
                                if (factors == null)
                                {
                                    return NotFound();
                                }
                                return View(factors);
                }
 
                [HttpPost]
                public IActionResult Edit_Factors(double Own_Damage_Premium_Discount_Percentage, double No_Claim_Discount_Percentage, double Accident_Cover, double Legal_Libility, double Third_Party, double Service_Tax_Percentage)
                {
                    bool status = InsuranceDBManager.UpdateFactors(Own_Damage_Premium_Discount_Percentage, No_Claim_Discount_Percentage, Accident_Cover, Legal_Libility, Third_Party, Service_Tax_Percentage);

                    if (status)
                    {
                        return RedirectToAction("Edit_Factors", "Insurance");
                    }
                    return View();
                }

    //--------------------------------------------------
             
                public IActionResult Total_Insurance(int id)
                {
                    Vehicle vehicle = VehicleDBManager.GetVehicleById(id);
                    
                    // Console.WriteLine($"vprice: {vehicle.Vprice}"); // Print vprice
                    // Console.WriteLine($"Date_of_Purchase: {vehicle.Date_of_Purchase}"); // Print Date_of_Purchase
 
                         
                        DateTime purchaseDate = DateTime.Parse(vehicle.Date_of_Purchase);
                        // Calculate the difference between current date and Date_of_Purchase in months
                        int Age = ((DateTime.Now.Year - purchaseDate.Year) * 12) + DateTime.Now.Month - purchaseDate.Month;
                        Console.WriteLine($"Months difference: {Age}");
                  
                        double Vprice = vehicle.Vprice;
                        Console.WriteLine($"Vprice : {Vprice}");


                    return View();
                }
  

    //----------------------------------------------------

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
