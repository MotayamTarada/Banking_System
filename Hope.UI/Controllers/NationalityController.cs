using Hope.Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hope.UI.Controllers
{
    public class NationalityController : BaseController
    {
        public NationalityController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> AddNewNationality(Hope.Infrastructure.DTO.NationalityDTO nationalityDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var natioalityContextDTO = JsonConvert.SerializeObject(nationalityDTO);

            var response = await client.PostAsync(url + "api/Nationality/AddNewNationality",
                new StringContent(natioalityContextDTO, Encoding.UTF8, "application/json"));

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Good;
            }
            else
            {
                // Error
            }
            return View();
        }
    }
}
