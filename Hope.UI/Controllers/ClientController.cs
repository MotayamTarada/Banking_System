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
    public class ClientController : BaseController
    {
        public ClientController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Create()
        {
            //
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Client/GetAllNationality");

            string apiResponse = await response.Content.ReadAsStringAsync();

            ViewBag.Nationality = JsonConvert.DeserializeObject<List<NationalityDTO>>(apiResponse);

            return View();
        }

        public async Task<IActionResult> AddNewClient(Hope.Infrastructure.DTO.ClientDTO clientDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var ClientContextDTO = JsonConvert.SerializeObject(clientDTO);

            var response = await client.PostAsync(url + "api/Client/AddNewClient",
                new StringContent(ClientContextDTO, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
                // Error Page
            }


        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Client/GetAllClient");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ClientDTO>>(apiResponse);

            return View(result);
        }


        public async Task<IActionResult> Update(int ID)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var responseNationality = await client.GetAsync(url + "api/Client/GetAllNationality");

            string apiResponseNationality = await responseNationality.Content.ReadAsStringAsync();

            ViewBag.Nationality = JsonConvert.DeserializeObject<List<NationalityDTO>>(apiResponseNationality);


            var response = await client.GetAsync(url + "api/Client/GetClientById?id=" + ID);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                ClientDTO clientDTO = JsonConvert.DeserializeObject<ClientDTO>(apiResponse);
                return View(clientDTO);
            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> Delete(int ID)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Client/DeleteClient?id=" + ID);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


        public async Task<IActionResult> UpdateClient(Hope.Infrastructure.DTO.ClientDTO clientDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var ClientContextDTO = JsonConvert.SerializeObject(clientDTO);

            var response = await client.PostAsync(url + "api/Client/UpdateClient",
                new StringContent(ClientContextDTO, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
                // Error Page
            }


        }

    }
}
