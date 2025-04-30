using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.User.Commands.SignInUser;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.User.Common;

namespace WageFlow.Tests.src.Entities.User.Commands
{
    public class SignInUserCommandHandlerTests : UserTestCommandBase
    {
        [Fact]
        public async Task SignInUserCommandHandler_Success()
        {
            var handler = new SignInUserCommandHandler(Context);
            var user_name = "Ivan123";
            var user_password = "qwe123";

            var result = await handler.Handle(
                new SignInUserCommand
                {
                    user_name = user_name,
                    user_password = user_password
                },
                CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(1, result.id_post);
            Assert.Equal(1, result.id_staff);
            Assert.Equal("Администратор", result.name_post);
        }
    }
}
