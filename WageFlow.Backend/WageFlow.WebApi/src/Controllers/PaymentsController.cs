using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Payments.Commands.DeletePayments;
using WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments;
using WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.WebApi.src.EntitiesDto.PaymentsDto;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : BaseController
    {
        private readonly IMapper _mapper;

        public PaymentsController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetPaymentsListVm>> GetAllPayments()
        {
            var query = new GetPaymentsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreatePayments([FromBody] CreatePaymentsDto createPaymentsDto)
        {
            var command = _mapper.Map<CreatePaymentsCommand>(createPaymentsDto);
            var id_payments = await Mediator.Send(command);
            return Ok(id_payments);
        }

        [HttpPut("Update/{id_payments}")]
        public async Task<IActionResult> UpdatePayments(int id_payments, [FromBody] UpdatePaymentsDto updatePaymentsDto)
        {
            var command = _mapper.Map<UpdatePaymentsCommand>(updatePaymentsDto);
            command.id_payments = id_payments;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_payments}")]
        public async Task<IActionResult> DeletePayments(int id_payments)
        {
            var command = new DeletePaymentsCommand
            {
                id_payments = id_payments
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
