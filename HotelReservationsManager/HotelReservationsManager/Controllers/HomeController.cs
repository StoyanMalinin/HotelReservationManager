using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManager.Controllers.Models;

namespace HotelReservationsManager.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseController ds;
        private readonly ILogger<HomeController> _logger;

        public static User loggedUser = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.ds = new DatabaseController(new HotelDb());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard(User u)
        {
            if (loggedUser is null) return NotFound();
            return View();
        }

        public IActionResult tryLogin(User u)
        {
            User match = ds.getFirstEntry<User>(x => x.username == u.username);

            if (match == null) return RedirectToAction(nameof(Index));
            if(match.isActive==false) return RedirectToAction(nameof(Index));
            if (match.password != u.password) return RedirectToAction(nameof(Index));

            loggedUser = match;
            return RedirectToAction(nameof(Dashboard));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
