using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : BaseController
    {
        private readonly IMapper _mapper;

        public StaffController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetStaffListVm>> GetAllStaffs()
        {
            var query = new GetStaffListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateStaff([FromBody] CreateStaffDto createStaffDto)
        {
            var command = _mapper.Map<CreateStaffCommand>(createStaffDto);
            var id_staff = await Mediator.Send(command);
            return Ok(id_staff);
        }

        [HttpPut("Update/{id_staff}")]
        public async Task<IActionResult> UpdateStaff(int id_staff, [FromBody] UpdateStaffDto updateStaffDto)
        {
            var command = _mapper.Map<UpdateStaffCommand>(updateStaffDto);
            command.id_staff = id_staff;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_staff}")]
        public async Task<IActionResult> DeleteStaff(int id_staff)
        {
            var command = new DeleteStaffCommand
            {
                id_staff = id_staff
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
