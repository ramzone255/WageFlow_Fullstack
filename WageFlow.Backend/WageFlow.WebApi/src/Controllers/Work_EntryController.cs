using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry;
using WageFlow.Application.src.Entities.Work_Entry.Commands.DeleteWork_Entry;
using WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry;
using WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;
using WageFlow.WebApi.src.EntitiesDto.Work_EntryDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Work_EntryController : BaseController
    {
        private readonly IMapper _mapper;

        public Work_EntryController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetWork_EntryListVm>> GetAllWork_Entry()
        {
            var query = new GetWork_EntryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateWork_Entry([FromBody] CreateWork_EntryDto createWork_EntryDto)
        {
            var command = _mapper.Map<CreateWork_EntryCommand>(createWork_EntryDto);
            var id_work_entry = await Mediator.Send(command);
            return Ok(id_work_entry);
        }

        [HttpPut("Update/{id_work_entry}")]
        public async Task<IActionResult> UpdatWork_Entry(int id_work_entry, [FromBody] UpdateWork_EntryDto updateWork_EntryDto)
        {
            var command = _mapper.Map<UpdateWork_EntryCommand>(updateWork_EntryDto);
            command.id_work_entry = id_work_entry;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("Delete/{id_work_entry}")]
        public async Task<IActionResult> DeleteWork_Entry(int id_work_entry)
        {
            var command = new DeleteWork_EntryCommand
            {
                id_work_entry = id_work_entry
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
