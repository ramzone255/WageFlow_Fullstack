using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.Post.Queries.GetPostList;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;

        public PostController(IMapper mapper) => _mapper = mapper;

        [HttpGet("List")]
        public async Task<ActionResult<GetPostListVm>> GetAllPosts()
        {
            var query = new GetPostListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
