using Microsoft.AspNetCore.Mvc;
using TheBank.Domain.LoanApplication;
using TheBank.Logic.LoanApplication;

namespace TheBank.Api.Controllers
{
    [Route("LoanApplication")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationLogic _loanApplicationLogic;

        public LoanApplicationController(ILoanApplicationLogic loanApplicationLogic)
        {
            _loanApplicationLogic = loanApplicationLogic;
        }


        [HttpGet("GetAll")]
        public IActionResult GetLoanApplication()
        {
            var data = _loanApplicationLogic.GetApplications();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet("Get")]
        public IActionResult GetLoanApplication(int id)
        {
            var data = _loanApplicationLogic.GetApplication(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Create")]
        public IActionResult Add([FromBody] LoanApplicationModel model)
        {
            if (model == null)
            {
                BadRequest();
            }
            // TODO: This should make sure all values are set (no null values)
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            var id = _loanApplicationLogic.CreateLoanApplication(model);
            return Ok(id);
        }


        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var wasAbleToDelete = _loanApplicationLogic.DeleteLoanApplication(id);
            if (wasAbleToDelete)
            {
                return NoContent();
            }
            return NotFound();
        }


        [HttpPost("Update")]
        public IActionResult Update([FromBody] LoanApplicationModel model)
        {
            if (model == null)
            {
                BadRequest();
            }

            // TODO: This should make sure all values are set (no null values)
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var id = _loanApplicationLogic.UpdateLoanApplication(model);
            if (id < 0)
            {
                NotFound();
            }
            return Ok(id);
        }

        [HttpGet("GetDecision")]
        public IActionResult GetApplicationDecision(int id)
        {
            var data = _loanApplicationLogic.GetApplicationDecision(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.Decision);
        }

    }
}
