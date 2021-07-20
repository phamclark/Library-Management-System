using LibraryBookStore.Models;
using LibraryBookStore.Models.Home;
using LibraryUnity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookStore.Controllers
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

        public IActionResult Privacy()
        {
            BookMarkModel model = new BookMarkModel()
            {
                QRIndex1 = $"data:image/Png;base64,{QRCoderGenerator.BarCodeConverter(QRCoderGenerator.BookFooterQR("HARRY POTTER AND THE SORCERER'S STONE"))}",
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
