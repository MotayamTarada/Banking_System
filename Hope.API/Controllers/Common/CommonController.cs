using Hope.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.API.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommonController : Controller
    {
        private readonly IEmployeeRepository _employeeReposority;
        private readonly IClientRepository _clientRepository;
        private readonly IAccountOpeningRepository _accountOpeningRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IRoleModuleRepository _roleModuleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleUserRepository _roleUserRepository;

        public CommonController(IEmployeeRepository employeeReposority,
            IClientRepository clientRepository, IAccountOpeningRepository accountOpeningRepository,
            ILoanRepository loanRepository, IModuleRepository moduleRepository,
            IRoleModuleRepository roleModuleRepository, IRoleRepository roleRepository, IRoleUserRepository roleUserRepository)
        {
            _employeeReposority = employeeReposority;
            _clientRepository = clientRepository;
            _accountOpeningRepository = accountOpeningRepository;
            _loanRepository = loanRepository;
            _moduleRepository = moduleRepository;
            _roleModuleRepository = roleModuleRepository;
            _roleRepository = roleRepository;
            _roleUserRepository = roleUserRepository;
        }

        public IActionResult FillDashboard()
        {
            Hope.Infrastructure.DTO.DashboardDTO dashboardDTO = new Infrastructure.DTO.DashboardDTO();
            dashboardDTO.NumberOfAccountOpening = _accountOpeningRepository.GetAll().Count();
            dashboardDTO.NumberOfClients = _clientRepository.GetAll().Count(); ;
            dashboardDTO.NumberOfEmployees = _employeeReposority.GetAll().Count();
            dashboardDTO.NumberOfLoans = _loanRepository.GetAll().Count(); ;

            string jsonString = JsonConvert.SerializeObject(dashboardDTO, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonString);
        }

        public IActionResult GetAllPermissionByUserId(int userId)
        {
            List<int> lstRoles = _roleUserRepository.Find(obj => obj.EmployeeId == userId).Select(obj => obj.RoleId).ToList();

            List<int> lstModules = _roleModuleRepository.Find(obj => lstRoles.Contains(obj.RoleId)).Select(obj => obj.ModuleId).Distinct().ToList();

            Hope.Infrastructure.DTO.MenuPermissionDTO menuPermissionDTO = new Infrastructure.DTO.MenuPermissionDTO();

            if (lstModules.Contains(1))
                menuPermissionDTO.Employees = "True";
            if (lstModules.Contains(2))
                menuPermissionDTO.Clients = "True";
            if (lstModules.Contains(3))
                menuPermissionDTO.Accounts = "True";
            if (lstModules.Contains(4))
                menuPermissionDTO.Loans = "True";

            return Ok(menuPermissionDTO);

        }
    }
}
