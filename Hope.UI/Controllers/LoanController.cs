using Hope.Infrastructure.Base;
using Hope.Infrastructure.DTO;
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
    public class LoanController : BaseController
    {
        public LoanController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Client/GetAllClient");
            string apiResponse = await response.Content.ReadAsStringAsync();
            ViewBag.Clients = JsonConvert.DeserializeObject<List<ClientDTO>>(apiResponse);


            var responseLoan = await client.GetAsync(url + "api/Loan/GetAllLoanType");
            string apiResponseLoan = await responseLoan.Content.ReadAsStringAsync();
            ViewBag.LoanType = JsonConvert.DeserializeObject<List<LoanTypeDTO>>(apiResponseLoan);

            return View();
        }

        public async Task<IActionResult> AddNewLoan(Hope.Infrastructure.DTO.LoanDTO loanDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var LoanContextDTO = JsonConvert.SerializeObject(loanDTO);

            var response = await client.PostAsync(url + "api/Loan/AddNewLoan",
                new StringContent(LoanContextDTO, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View();
            }
            else
            {
                return View("~/Views/Home/ErrorPage.cshtml");
            }
        }
    }
}
