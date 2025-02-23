using Hope.Infrastructure.DTO;
using Hope.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.API.Controllers.Loan
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoanController : Controller
    {
        private readonly ILoanTypeRepository _loanTypeRepository;
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILoanTypeRepository loanTypeRepository, ILoanRepository loanRepository)
        {
            _loanTypeRepository = loanTypeRepository;
            _loanRepository = loanRepository;
        }

        public IActionResult GetAllLoanType()
        {

            List<LoanTypeDTO> lst = (from obj in _loanTypeRepository.GetAll()
                                     select new LoanTypeDTO
                                     {
                                         LoanTypeId = obj.LoanTypeId,
                                         TypeName = obj.TypeName,
                                     }).ToList();

            string jsonString = JsonConvert.SerializeObject(lst, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonString);
        }


        public IActionResult AddNewLoan(Hope.Infrastructure.DTO.LoanDTO loanDTO)
        {
            DomainEntities.DBEntities.Loan loan = new DomainEntities.DBEntities.Loan();

            loan.ClientId = loanDTO.ClientId;
            loan.Curreny = loanDTO.Curreny;
            loan.EndDate = loanDTO.EndDate;
            loan.StartDate = loanDTO.StartDate;
            loan.InterestRate = loanDTO.InterestRate;
            loan.LoanAmount = loanDTO.LoanAmount;
            loan.LoanPeriod = loanDTO.LoanPeriod;
            loan.LoanSattelmentAmount = loanDTO.LoanSattelmentAmount;
            loan.LoanTypeId = loanDTO.LoanTypeId;
            loan.TaxValue = loanDTO.TaxValue;
            loan.TotalAmountwithInterest = loanDTO.TotalAmountwithInterest;

            _loanRepository.Add(loan);

            return Ok("Success");
        }
    }
}
