using Hope.Infrastructure.DTO;
using Hope.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.API.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UserController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _employeeRepository.Find(x => x.Username == loginDTO.UserName
            && x.Password == loginDTO.Password).FirstOrDefault();
            
            if(result != null )
            {
                return Ok(result.EmployeeId);
            }
            else
            {
                return BadRequest(-1);
            }

        }
    }
}
