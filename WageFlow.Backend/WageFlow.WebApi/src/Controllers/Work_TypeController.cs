using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Work_TypeController : BaseController
    {
        private readonly IMapper _mapper;

        public Work_TypeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetWork_TypeListVm>> GetAllWork_Types()
        {
            var query = new GetWork_TypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
