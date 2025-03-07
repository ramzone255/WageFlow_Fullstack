using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WageFlow.Application.src.Entities.User.Commands.SignInUser;

namespace WageFlow.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInUserCommand command)
        {
            var response = await Mediator.Send(command);

            if (response == null)
            {
                return Unauthorized(new { message = "Неверный логин или пароль" });
            }

            return Ok(response);
        }
    }
}
