using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareRooterApp.Models;

namespace SquareRooterApp.Controllers
{
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult Squarer() {
            return View();
        }

        [HttpPost]
        public IActionResult Squarer(string firstNumber, string secondNumber) {
            ViewBag.Result = SqrtMethod(firstNumber, secondNumber);
            return View();
        }

        private static String SqrtMethod(string firstNo, string secondNo) {
            int firstNumber;
            int secondNumber;
            string display = string.Empty;
            bool isConvertedNo1 = int.TryParse(firstNo, out firstNumber);
            bool isConvertedNo2 = int.TryParse(secondNo, out secondNumber);


            if (firstNo == "" || secondNo == "") {
                display = "Please input a value";
            }
            
            else if (isConvertedNo1 && isConvertedNo2) {
                if (firstNumber < 0 || secondNumber < 0) {
                    display = "Error! This is not a valid input. It is a negative number";
                }
                else {

                    double SqNO1 = Math.Sqrt(firstNumber);
                    double SqNO2 = Math.Sqrt(secondNumber);

                    if (SqNO1 > SqNO2) {
                        display = "The number " + firstNumber + " with Square root " + SqNO1 + " has a Higher square root than the number " + secondNumber + " with square root " + SqNO2;
                    }
                    else if (SqNO1 < SqNO2) {
                        display = "The number " + secondNumber + " with Square root " + SqNO2 + " has a Higher square root than the number " + firstNumber + " with square root " + SqNO1;
                    }
                    else if (SqNO1 == SqNO2) {
                        display = "These Values are Equal. Please enter another value";
                    }
                }
            }
            else {
                display = "Invalid! Please enter a valid number";
            }

            return display;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
