using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.DeleteWork_Entry_Salary_Payment;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.UpdateWork_Entry_Salary_Payment;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Queries.GetWork_Entry_Salary_PaymentList;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;
using WageFlow.WebApi.src.EntitiesDto.Work_Entry_Salary_PaymentDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Work_Entry_Salary_PaymentController : BaseController
    {
        private readonly IMapper _mapper;

        public Work_Entry_Salary_PaymentController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetWork_Entry_Salary_PaymentListVm>> GetAllWork_Entry_Salary_Payments()
        {
            var query = new GetWork_Entry_Salary_PaymentListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateWork_Entry_Salary_Payment([FromBody] CreateWork_Entry_Salary_PaymentDto createWork_Entry_Salary_PaymentDto)
        {
            var command = _mapper.Map<CreateWork_Entry_Salary_PaymentCommand>(createWork_Entry_Salary_PaymentDto);
            var id_work_entry_salary_payment = await Mediator.Send(command);
            return Ok(id_work_entry_salary_payment);
        }

        [HttpPut("Update/{id_work_entry_salary_payment}")]
        public async Task<IActionResult> UpdateWork_Entry_Salary_Payment(int id_work_entry_salary_payment, [FromBody] UpdateWork_Entry_Salary_PaymentDto updateWork_Entry_Salary_PaymentDto)
        {
            var command = _mapper.Map<UpdateWork_Entry_Salary_PaymentCommand>(updateWork_Entry_Salary_PaymentDto);
            command.id_work_entry_salary_payment = id_work_entry_salary_payment;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_work_entry_salary_payment}")]
        public async Task<IActionResult> DeleteWork_Entry_Salary_Payment(int id_work_entry_salary_payment)
        {
            var command = new DeleteWork_Entry_Salary_PaymentCommand
            {
                id_work_entry_salary_payment = id_work_entry_salary_payment
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
