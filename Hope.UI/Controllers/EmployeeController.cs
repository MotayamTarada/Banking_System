using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hope.Infrastructure.DTO;
using System.Text;
using Hope.Infrastructure.Base;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Hope.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        public EmployeeController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Create()
        {
            //
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var response = await client.GetAsync(url + "api/Employee/GetAllQualification");

            string apiResponse = await response.Content.ReadAsStringAsync();

            ViewBag.Qualification = JsonConvert.DeserializeObject<List<QualificationDTO>>(apiResponse);

            return View();
        }

        public async Task<IActionResult> AddNewEmployee([FromForm]Hope.Infrastructure.DTO.EmployeeDTO employeeDTO)
        {
            //"E:\\HopeImages"
            string folderName = DateTime.Now.Ticks.ToString();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/" + folderName);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            //FileInfo fileInfo = new FileInfo(employeeDTO.IDCard.FileName);
            string fileName = employeeDTO.IDCard.FileName; //+ fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                employeeDTO.IDCard.CopyTo(stream);
            }

            employeeDTO.IDCard = null;
            employeeDTO.IdcardPath = folderName + "/" + fileName;

              HttpClient client = new HttpClient();
            string url = "http://localhost:50108/";

            var EmployeeContextDTO = JsonConvert.SerializeObject(employeeDTO);

            var response = await client.PostAsync(url + "api/Employee/AddNewEmployee",
                new StringContent(EmployeeContextDTO, Encoding.UTF8, "application/json"));

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
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
            try
            {


                HttpClient client = new HttpClient();
                string url = configuration.GetSection("APIURL").Value.ToString();

                var response = await client.GetAsync(url + "api/Employee/GetAllEmployee");
                string apiResponse = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(apiResponse);

                return View(result);
            }
            catch (Exception ex)
            {

                return View("~/Views/Home/ErrorPage.cshtml");

            }
        }


        public async Task<IActionResult> Update(int ID)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var Qualificationresponse = await client.GetAsync(url + "api/Employee/GetAllQualification");

            string QualificationapiResponse = await Qualificationresponse.Content.ReadAsStringAsync();

            ViewBag.Qualification = JsonConvert.DeserializeObject<List<QualificationDTO>>(QualificationapiResponse);


            var response = await client.GetAsync(url + "api/Employee/GetEmployeeById?id=" + ID);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                EmployeeDTO employeeDTO = JsonConvert.DeserializeObject<EmployeeDTO>(apiResponse);
                return View(employeeDTO);
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

            var response = await client.GetAsync(url + "api/Employee/DeleteEmployee?id=" + ID);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
                  

        public async Task<IActionResult> UpdateEmployee(Hope.Infrastructure.DTO.EmployeeDTO employeeDTO)
        {
            HttpClient client = new HttpClient();
            string url = configuration.GetSection("APIURL").Value.ToString();

            var EmployeeContextDTO = JsonConvert.SerializeObject(employeeDTO);

            var response = await client.PostAsync(url +     loyee",
                new StringContent(EmployeeContextDTO, Encoding.UTF8, "application/json"));

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
