using FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FBPage()
        {
            // Instantiate a new model class called model derived from FizzBuzz model class
            FizzBuzz model = new();

            // Assign default values to model properties
            model.FizzValue = 3;
            model.BuzzValue = 5;

            // Make sure to pass the model class data to the view/client-side UI
            return View(model);
        }

        [HttpPost]
        // Validate form is from our web app and not somewhere else
        [ValidateAntiForgeryToken]
        // Create public IAR with FizzBuzz model type class passed as a property named fizzbuzz, which will store form submitted data
        public IActionResult FBPage(FizzBuzz fizzbuzz)
        {
            // Instantiate a list of strings called fbItems to store fizzbuzz looping results
            List<string> fbItems = new();

            // Create bool fizz/buzz variables to manipulate 
            bool fizz;
            bool buzz;

            // Loop through 1 - 100 checking if numbers are divisible by fizz, buzz, or both
            for (int i = 1; i <= 100; i++)
            {
                fizz = (i % fizzbuzz.FizzValue == 0);
                buzz = (i % fizzbuzz.BuzzValue == 0);

                if (fizz && buzz)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz)
                {
                    fbItems.Add("Fizz");
                }
                else if (buzz)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }

            }

            return View(fizzbuzz);
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
}
