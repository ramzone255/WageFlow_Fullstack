using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.CreateSalary_Payment_Payments;
using WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.DeleteSalary_Payment_Payments;
using WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.UpdateSalary_Payment_Payments;
using WageFlow.Application.src.Entities.Salary_Payment_Payments.Queries.GetSalary_Payment_PaymentsList;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.WebApi.src.EntitiesDto.Salary_Payment_PaymentsDto;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Salary_Payment_PaymentsController : BaseController
    {
        private readonly IMapper _mapper;

        public Salary_Payment_PaymentsController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetSalary_Payment_PaymentsListVm>> GetAllSalary_Payment_Payments()
        {
            var query = new GetSalary_Payment_PaymentsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateSalary_Payment_Payments([FromBody] CreateSalary_Payment_PaymentsDto createSalary_Payment_PaymentsDto)
        {
            var command = _mapper.Map<CreateSalary_Payment_PaymentsCommand>(createSalary_Payment_PaymentsDto);
            var id_salary_payment_payments = await Mediator.Send(command);
            return Ok(id_salary_payment_payments);
        }

        [HttpPut("Update/{id_salary_payment_payments}")]
        public async Task<IActionResult> UpdateSalary_Payment_Payments(int id_salary_payment_payments, [FromBody] UpdateSalary_Payment_PaymentsDto updateSalary_Payment_PaymentsDto)
        {
            var command = _mapper.Map<UpdateSalary_Payment_PaymentsCommand>(updateSalary_Payment_PaymentsDto);
            command.id_salary_payment_payments = id_salary_payment_payments;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_salary_payment_payments}")]
        public async Task<IActionResult> DeleteSalary_Payment_Payments(int id_salary_payment_payments)
        {
            var command = new DeleteSalary_Payment_PaymentsCommand
            {
                id_salary_payment_payments = id_salary_payment_payments
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
