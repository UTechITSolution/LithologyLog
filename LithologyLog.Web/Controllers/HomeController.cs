using LithologyLog.Web.Lang;
using LithologyLog.Web.Models;
using LithologyLog.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LithologyLog.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly LocalizerService _localizerService;

        public HomeController(LocalizerService localizerService)
        {
            _localizerService = localizerService;

        }

        public IActionResult Index()
        {
            ViewBag.Tittle = _localizerService["Tittle"];
            
            return View();
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
