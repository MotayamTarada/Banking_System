using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetFullName()
        {
            List<Custom> lst = new List<Custom>();

            Custom obj = new Custom();
            obj.FirstName = "Ahmad";
            obj.LastName = "Saleh";
            obj.Email = "Test@test.com";
            lst.Add(obj);


            obj = new Custom();
            obj.FirstName = "Ayed";
            obj.LastName = "Rabaya";
            obj.Email = "Test@test.com";
            lst.Add(obj);

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult AddNewUser(string FirstName, string LastName)
        {
            return Ok();
        }

        public class Custom
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    }
}
