using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FrontSite.Models;
using Microsoft.Extensions.Options;
using JCSoft.SSA.Configurations;
using JCSoft.SSA.Tools.Http;

namespace FrontSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly SSAConfiguration _configuration;
        private readonly IHttpHelper _httpHelper;
        public HomeController(IOptions<SSAConfiguration> options,
            IHttpHelper httpHelper)
        {
            _configuration = options.Value;
            _httpHelper = httpHelper;
        }
        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            object model = await _httpHelper.GetAsync(_configuration.ServicesUri + "/api/values");

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
