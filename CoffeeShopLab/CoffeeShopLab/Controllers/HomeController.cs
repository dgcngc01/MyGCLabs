using CoffeeShopLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeShopLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        //model binding
        [HttpPost]
        public IActionResult HandleSubmit(UserProfile userProfile)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Welcome", userProfile);
        }

        //Home/Welcome
        public IActionResult Welcome(UserProfile userProfile)
        {
            return View(userProfile);
        }
    }
}