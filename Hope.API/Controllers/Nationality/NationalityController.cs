using Hope.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hope.DomainEntities;
using Hope.Repositories;

namespace Hope.API.Controllers.Nationality
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NationalityController : Controller
    {
       private readonly INationalityRepository _nationalityRepository;

       public NationalityController(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }

        public IActionResult GetAllNationality()
        {
            var result = _nationalityRepository.GetAll().ToList();

            string jsonString = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(jsonString);
        }

        public IActionResult AddNewNationality(Hope.Infrastructure.DTO.NationalityDTO nationalityDTO)
        {
            DomainEntities.DBEntities.Nationality obj = new DomainEntities.DBEntities.Nationality();
            obj.NationalityName = nationalityDTO.NationalityName;

            _nationalityRepository.Add(obj);

            return Ok("Ok");
        }

        public IActionResult UpdateNationality(int Id, string Name)
        {
            DomainEntities.DBEntities.Nationality obj = new DomainEntities.DBEntities.Nationality();
            obj = _nationalityRepository.GetAll().Where(x => x.NationalityId == Id).FirstOrDefault();

            obj.NationalityName = Name;
            _nationalityRepository.Update(obj);


            return Ok("");
        }
    }
}
