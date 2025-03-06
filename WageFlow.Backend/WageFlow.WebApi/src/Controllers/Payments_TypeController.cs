using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Payments_TypeController : BaseController
    {
        private readonly IMapper _mapper;

        public Payments_TypeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetPayments_TypeListVm>> GetAllPayments_Types()
        {
            var query = new GetPayments_TypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
