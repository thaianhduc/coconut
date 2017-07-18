using System;
using System.Globalization;
using Coconut.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coconut.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Serve the GET /home/uglyfact?birthday=dd-MM-yyyy
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public IActionResult UglyFact(string birthday)
        {
            // Ignore all data validation. Simply assume that the request is correct.
            var dob = DateTime.ParseExact(birthday, "dd-MM-yyyy", CultureInfo.CurrentCulture);
            var meetCreatorOn = dob.AddYears(80);
            var spent = (int)Math.Round(DateTime.Now.Subtract(dob).TotalDays / 7);
            var closed = (int)Math.Round(meetCreatorOn.Subtract(DateTime.Now).TotalDays / 7);
            return View( new UglyFactModel
            {
                SpentWeeks = spent,
                CloseToCreatorWeeks = closed
            });
        }
    }
}
