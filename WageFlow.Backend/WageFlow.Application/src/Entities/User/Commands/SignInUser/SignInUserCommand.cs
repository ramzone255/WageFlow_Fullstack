using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.User.Commands.SignInUser
{
    public class SignInUserCommand : IRequest<SignInUserCommandVm?>
    {
        public string user_name { get; set; }
        public string user_password { get; set; }
    }
}
