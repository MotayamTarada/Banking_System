using Hope.Infrastructure.Base;
using Hope.Infrastructure.DTO;
using Hope.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hope.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration) : base(configuration)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Common/FillDashboard");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<DashboardDTO>(apiResponse);

            return View(result);
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

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Change(Hope.Infrastructure.DTO.ChangePasswordDTO changePasswordDTO)
        {

            return RedirectToAction("Index");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
