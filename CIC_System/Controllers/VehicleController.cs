
using Microsoft.AspNetCore.Mvc;
using CIC_System.Models;
using DAL;
using Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;

namespace CIC_System.Controllers
{
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
   
        // Vehicle_Registration method
        public IActionResult Vehicle_Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Vehicle_Registration(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type)
        {
            int userID = GetUserID();
            if (userID == 0)
            {
                // Handle the case when userID is not available
                // You can redirect the user to login or handle it in any other appropriate way
                // For now, I'm just returning a view with an error message
                ViewBag.ErrorMessage = "User ID is not available.";
                return View("Error");
            }
         
            Console.WriteLine("Vehicle ID: " + vid);
            Console.WriteLine("Vehicle Number: " + vno);
            Console.WriteLine("Vehicle Price: " + vprice);
            Console.WriteLine("Vehicle Company: " + vcompany);
            Console.WriteLine("Date of Purchase: " + date_of_Purchase);
            Console.WriteLine("Engine Number: " + engine_no);
            Console.WriteLine("Fuel Type: " + fuel_Type);
            Console.WriteLine("User ID: " + userID);

            bool status = VehicleDBManager.AddVehicle(vid, vno, vprice, vcompany, date_of_Purchase, engine_no, fuel_Type, userID);

            if (status)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //-----------------------------------------------------------------

        public IActionResult Vehicle_List()
        {
            int userID = GetUserID();
            if (userID == 0)
            {
                // Handle the case when userID is not available
                // You can redirect the user to login or handle it in any other appropriate way
                // For now, I'm just returning a view with an error message
                ViewBag.ErrorMessage = "User ID is not available.";
                return View("Error");
            }

            List<Vehicle> vehicles = VehicleDBManager.GetAllVehicles(userID);
            return View(vehicles);
        }

        //-----------------------------------------------------------------

   
             [HttpGet]
            public IActionResult Vehicle_Edit(int id)
                {
                    Vehicle vehicle = VehicleDBManager.GetVehicleById(id);
                    if (vehicle == null)
                    {
                        return NotFound();
                    }
                    return View(vehicle);
                }

                [HttpPost]
                public IActionResult Vehicle_Edit(int vid, string vno, double vprice, string vcompany, string date_of_Purchase, string engine_no, string fuel_Type)
                {
                    Console.WriteLine("Vehicle ID: " + vid);
                    Console.WriteLine("Vehicle Number: " + vno);
                    Console.WriteLine("Vehicle Price: " + vprice);
                    Console.WriteLine("Vehicle Company: " + vcompany);
                    Console.WriteLine("Date of Purchase: " + date_of_Purchase);
                    Console.WriteLine("Engine Number: " + engine_no);
                    Console.WriteLine("Fuel Type: " + fuel_Type);
                   
                    bool status = VehicleDBManager.UpdateVehicle(vid, vno, vprice, vcompany, date_of_Purchase, engine_no, fuel_Type);

                    if (status)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }


        //--------------------------------------------------------------------

        public IActionResult Vehicle_View(int id)
        {
                   Vehicle vehicle = VehicleDBManager.GetVehicleById(id);
                    if (vehicle == null)
                    {
                        return NotFound();
                    }
                    return View(vehicle);       
        }
        //---------------------------------------------------------------------
                
            
            public IActionResult Vehicle_Delete(int id)
            {
                bool status = VehicleDBManager.DeleteVehicle(id);

                if (status)
                {
                    return RedirectToAction("Vehicle_List", "Vehicle");
                }
                return RedirectToAction("Index", "Home");
            }
        

        //--------------------------------------------------------
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(errorViewModel);
        }

        private int GetUserID()
        {
            if (TempData.ContainsKey("data") && TempData["data"] != null)
            {
                return (int)TempData["data"];
            }
            return 0;
        }
    }
}
