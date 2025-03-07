using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.DeleteSalary_Payment;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment;
using WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.WebApi.src.EntitiesDto.Salary_PaymentDto;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Salary_PaymentController : BaseController
    {
        private readonly IMapper _mapper;

        public Salary_PaymentController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetSalary_PaymentListVm>> GetAllSalary_Payments()
        {
            var query = new GetSalary_PaymentListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateSalary_Payment([FromBody] CreateSalary_PaymentDto createSalary_PaymentDto)
        {
            var command = _mapper.Map<CreateSalary_PaymentCommand>(createSalary_PaymentDto);
            var id_salary_payment = await Mediator.Send(command);
            return Ok(id_salary_payment);
        }

        [HttpPut("Update/{id_salary_payment}")]
        public async Task<IActionResult> UpdateSalary_Payment(int id_salary_payment, [FromBody] UpdateSalary_PaymentDto updateSalary_PaymentDto)
        {
            var command = _mapper.Map<UpdateSalary_PaymentCommand>(updateSalary_PaymentDto);
            command.id_salary_payment = id_salary_payment;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_salary_payment}")]
        public async Task<IActionResult> DeleteSalary_Payment(int id_salary_payment)
        {
            var command = new DeleteSalary_PaymentCommand
            {
                id_salary_payment = id_salary_payment
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
