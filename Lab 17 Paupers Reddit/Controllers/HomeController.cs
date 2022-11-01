using Lab_17_Paupers_Reddit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_17_Paupers_Reddit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PauperDAL pd = new PauperDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Use async here to reference PauperDAL
        public async Task<IActionResult> DisplayPauper(string s)
        {
         //ModelState: Gets the Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary that contains
         //the state of the model and of model-binding validation.
            if (string.IsNullOrEmpty(s) || ModelState.IsValid)
            {
                var reddit = await pd.RedditFiles(s);
                return View(reddit);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Index()
        {
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