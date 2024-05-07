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
                      //receive data from Vehicle table
                      Vehicle vehicle = VehicleDBManager.GetVehicleById(id);
                    
                    // Console.WriteLine($"vprice: {vehicle.Vprice}"); // Print vprice
                    // Console.WriteLine($"Date_of_Purchase: {vehicle.Date_of_Purchase}"); // Print Date_of_Purchase
 
                         
                        DateTime purchaseDate = DateTime.Parse(vehicle.Date_of_Purchase);
                        // Calculate the difference between current date and Date_of_Purchase in months
                        int Age = ((DateTime.Now.Year - purchaseDate.Year) * 12) + DateTime.Now.Month - purchaseDate.Month;
                        Console.WriteLine($"Months difference: {Age}");
                  
                        double Vprice = vehicle.Vprice;
                        Console.WriteLine($"Vprice : {Vprice}");

                        string Vno = vehicle.Vno;
                        Console.WriteLine($"Vno : {Vno}");


                        //receive data from Factors table
                         Factors factors = InsuranceDBManager.GetFactorsById(1);
                       
                         double Own_Damage_Premium_Discount_Percentage = factors.Own_Damage_Premium_Discount_Percentage;
                         double No_Claim_Discount_Percentage = factors.No_Claim_Discount_Percentage;
                         double Accident_Cover = factors.Accident_Cover;
                         double Legal_Libility = factors.Legal_Libility;
                         double Third_Party = factors.Third_Party;
                         double Service_Tax_Percentage = factors.Service_Tax_Percentage;

                            // Console.WriteLine($"Own Damage Premium Discount Percentage: {Own_Damage_Premium_Discount_Percentage}");
                            // Console.WriteLine($"No Claim Discount Percentage: {No_Claim_Discount_Percentage}");
                            // Console.WriteLine($"Accident Cover: {Accident_Cover}");
                            // Console.WriteLine($"Legal Liability: {Legal_Libility}");
                            // Console.WriteLine($"Third Party: {Third_Party}");
                            // Console.WriteLine($"Service Tax Percentage: {Service_Tax_Percentage}");
                       
                          double Depreciation_Percentage = 0;
                          double Depreciation_Amount = 0;
                          double Insured_Declared_Amount = 0;
                          double Own_Damage_Premium = 0;
                          double No_Claim_Discount = 0;
                          double Total_Own_Damage_Premium = 0;
                          double Net_Premium = 0;
                          double Service_Tax = 0;
                          double Total_Premium = 0;

                          // 1) calculate Depreciation_Percentage - 
                          if(Age <=12)
                          {
                            Depreciation_Percentage = 10;
                          }
                          else if(Age >=12 && Age <= 24)
                          {
                            Depreciation_Percentage = 15;
                          }
                          else if(Age >=25 && Age <= 36)
                          {
                            Depreciation_Percentage = 20;
                          } 
                          else if(Age >=37 && Age <= 48)
                          {
                            Depreciation_Percentage = 25;
                          }
                          else if(Age >=49 && Age <= 60)
                          {
                            Depreciation_Percentage = 30;
                          }
                          else if(Age >=60)
                          {
                            Depreciation_Percentage = 50;
                          }


                      // 2) calculate Depreciation_Amount - 
                       Depreciation_Amount = (Vprice * Depreciation_Percentage )/100;

                      // 3) calculate Insured_Declared_Amount - 
                       Insured_Declared_Amount = Vprice - Depreciation_Amount;

                      // 4) calculate Own_Damage_Premium - 
                       Own_Damage_Premium = (Insured_Declared_Amount * Own_Damage_Premium_Discount_Percentage)/100;
                      
                      // 5) calculate No_Claim_Discount - 
                       No_Claim_Discount = (Own_Damage_Premium * No_Claim_Discount_Percentage)/100;

                      // 6) calculate Total_Own_Damage_Premium - 
                       Total_Own_Damage_Premium = Own_Damage_Premium - No_Claim_Discount;

                      // 8) calculate Net_Premium - 
                       Net_Premium = Total_Own_Damage_Premium + Accident_Cover + Legal_Libility + Third_Party;

                      // 9) calculate Service_Tax - 
                       Service_Tax = (Net_Premium * Service_Tax_Percentage)/100;
                                             
                      // 10) calculate Total_Premium -
                       Total_Premium = Net_Premium + Service_Tax;
           
                        // Console.WriteLine("Depreciation Amount: " + Depreciation_Amount);
                        // Console.WriteLine("Insured Declared Amount: " + Insured_Declared_Amount);
                        // Console.WriteLine("Own Damage Premium: " + Own_Damage_Premium);
                        // Console.WriteLine("No Claim Discount: " + No_Claim_Discount);
                        // Console.WriteLine("Total Own Damage Premium: " + Total_Own_Damage_Premium);
                        // Console.WriteLine("Net Premium: " + Net_Premium);
                        // Console.WriteLine("Service Tax: " + Service_Tax);
                        // Console.WriteLine("Total Premium: " + Total_Premium);

                          // Store the calculated values in ViewData
                          ViewData["Vno"] = Vno;
                          ViewData["Age"] = Age;
                          ViewData["Vprice"] = Vprice;
                          ViewData["Accident_Cover"] = Accident_Cover;
                          ViewData["Legal_Libility"] = Legal_Libility;
                          ViewData["Third_Party"] = Third_Party;



                          ViewData["Depreciation_Amount"] = Depreciation_Amount;
                          ViewData["Insured_Declared_Amount"] = Insured_Declared_Amount;
                          ViewData["Own_Damage_Premium"] = Own_Damage_Premium;
                          ViewData["No_Claim_Discount"] = No_Claim_Discount;
                          ViewData["Total_Own_Damage_Premium"] = Total_Own_Damage_Premium;
                          ViewData["Net_Premium"] = Net_Premium;
                          ViewData["Service_Tax"] = Service_Tax;
                          ViewData["Total_Premium"] = Total_Premium;

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
