using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Videos.Models;

namespace TatterFitness.Videos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVideoService videoSvc;

        public HomeController(ILogger<HomeController> logger, IVideoService videoSvc)
        {
            _logger = logger;
            this.videoSvc = videoSvc;
        }

        public IActionResult Index()
        {
            return View(videoSvc.ReadWorkoutVideos());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
