using System;
using System.Globalization;
using Coconut.CoreLogic;
using Microsoft.AspNetCore.Mvc;

namespace Coconut.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UglyFactTeller _uglyFactTeller;

        public HomeController(UglyFactTeller uglyFactTeller)
        {
            _uglyFactTeller = uglyFactTeller;
        }
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
            return View( _uglyFactTeller.TellMe(dob));
        }
    }
}
