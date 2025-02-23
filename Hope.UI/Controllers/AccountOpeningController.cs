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
    public class AccountOpeningController : BaseController
    {
        public AccountOpeningController(IConfiguration configuration): base (configuration)
        {

        }
        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/AccountOpening/GetAllClient"); 
            string apiResponse = await response.Content.ReadAsStringAsync();
            ViewBag.Clients = JsonConvert.DeserializeObject<List<ClientDTO>>(apiResponse);


            var responseType = await client.GetAsync(url + "api/AccountOpening/GetAllAccountType");
            string apiResponseType = await responseType.Content.ReadAsStringAsync();
            ViewBag.AccountTypes = JsonConvert.DeserializeObject<List<AccountTypeDTO>>(apiResponseType);

            return View();
        }

        public async Task<IActionResult> CheckIfUserHasAccount(int AccountTypeId, int ClientId)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/AccountOpening/CheckIfUserHasAccount?AccountTypeId=" 
                + AccountTypeId + "&ClientId=" + ClientId);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
               // string status = JsonConvert.DeserializeObject<string>(apiResponse);
                return Json(apiResponse);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> AddNewAccountOpening(Hope.Infrastructure.DTO.AccountOpeningDTO accountOpeningDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();
            try
            {
                var accountOpeningContextDTO = JsonConvert.SerializeObject(accountOpeningDTO);

                var response = await client.PostAsync(url + "api/AccountOpening/AddNewAccountOpening",
                    new StringContent(accountOpeningContextDTO, Encoding.UTF8, "application/json"));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return View();
                }
                else
                {
                    return View("~/Views/Home/ErrorPage.cshtml");
                }
            }
            catch (Exception ex)
            {
                ErrorLogDTO errorLogDTO = new ErrorLogDTO();
                errorLogDTO.ModuleName = "Add New Account Opening";
                errorLogDTO.ErrorMessage = ex.Message;

                var ErrorContextDTO = JsonConvert.SerializeObject(errorLogDTO);
                var ErrorResponse = await client.PostAsync(url + "api/ErrorLog/AddError",
                 new StringContent(ErrorContextDTO, Encoding.UTF8, "application/json"));
                return View("~/Views/Home/ErrorPage.cshtml");
            }

        }
    }
}
