using Hope.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.API.Controllers.ErrorLog
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ErrorLogController : Controller
    {
        private readonly IErrorLogRepository _errorLogRepository;

        public ErrorLogController(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public IActionResult AddError(Hope.Infrastructure.DTO.ErrorLogDTO errorLogDTO)
        {
            DomainEntities.DBEntities.ErrorLog errorLog = new DomainEntities.DBEntities.ErrorLog();

            errorLog.ErrorDate = DateTime.Now;
            errorLog.ErrorMessage = errorLogDTO.ErrorMessage;
            errorLog.ModuleName = errorLogDTO.ModuleName;

            _errorLogRepository.Add(errorLog);

            return Ok("");
        }
    }
}
