// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using CIC_System.Models;
// using DAL;

// namespace CIC_System.Controllers;

// public class LoginController : Controller
// {
//     private readonly ILogger<LoginController> _logger;

//     public LoginController(ILogger<LoginController> logger)
//     {
//         _logger = logger;
//     }

//     public IActionResult Index()
//     {
//         return View();
//     }

//        //for login --------------------------------------------------------------
//        public IActionResult Login()
//         {
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Login(string username, string password)
//         {
//             if(username == "Admin" && password == "Admin")
//             {
//                 // Redirect to dashboard or any other page after successful login
//                 return RedirectToAction("Index", "Home");
//             }
//             else
//             {
//                 // Invalid login, show error message
//                 ViewBag.Error = "Invalid username or password";
//                 Console.WriteLine("Invalid Password");
//                 return View();
//             }
//         }


//       //for User_Registration ------------------------------------------------
//        public IActionResult User_Registration()
//         {
//             return View();
//         }
        
//         [HttpPost]
//         public IActionResult User_Registration(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, IFormFile image)
//         {
//                 bool status = DBManager.AddUser(id,name,age,mobile,aadhar_no,licence_no,address,gender,password,image);
//          // Your code to process the form data goes here
//             Console.WriteLine($"Id: {id}");
//             Console.WriteLine($"Name: {name}");
//             Console.WriteLine($"Age: {age}");
//             Console.WriteLine($"Mobile: {mobile}");
//             Console.WriteLine($"Aadhar No: {aadhar_no}");
//             Console.WriteLine($"Licence No: {licence_no}");
//             Console.WriteLine($"Address: {address}");
//             Console.WriteLine($"Gender: {gender}");
//             Console.WriteLine($"Password: {password}");
            
//             if (image != null)
//             {
//                 Console.WriteLine($"Image name: {image.FileName}");
//                 // You can add additional code here to save the image or process it as needed
//             }
//             else
//             {
//                 Console.WriteLine("No image uploaded");
//             }
// //------------------------------
//                 if (status)
//                 {
//                   return RedirectToAction("Index", "Home");
//                 }
//                 return View();

           
//             // Redirect to home page
//             return RedirectToAction("Index", "Home");
//         }


//         //------------------------------------------------------------------

//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using CIC_System.Models;
using DAL;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CIC_System.Controllers
{
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

        //for login --------------------------------------------------------------
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "Admin" && password == "Admin")
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


        //for User_Registration ------------------------------------------------
        public IActionResult User_Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult User_Registration(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, IFormFile image)
        {
            bool status = DBManager.AddUser(id, name, age, mobile, aadhar_no, licence_no, address, gender, password, image);

            // Your code to process the form data goes here
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Mobile: {mobile}");
            Console.WriteLine($"Aadhar No: {aadhar_no}");
            Console.WriteLine($"Licence No: {licence_no}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Password: {password}");

            if (image != null)
            {
                Console.WriteLine($"Image name: {image.FileName}");
                // You can add additional code here to save the image or process it as needed
            }
            else
            {
                Console.WriteLine("No image uploaded");
            }

            if (status)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //------------------------------------------------------------------

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
}

