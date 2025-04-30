using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Staff.Common;

namespace WageFlow.Tests.src.Entities.Staff.Commands
{
    public class CreateStaffCommandHandlerTests : StaffTestCommandBase
    {
        [Fact]
        public async Task CreateStaffCommandHandler_Success()
        {
            var handler = new CreateStaffCommandHandler(Context);
            var lastname_staff = "Имя 1";
            var name_staff = "Фамилия 1";
            var patronymic_staff = "Отчество 1";
            var email_staff = "Почта 1";
            var id_post = 1;

            var id_staff = await handler.Handle(
                new CreateStaffCommand
                {
                    lastname_staff = lastname_staff,
                    name_staff = name_staff,
                    patronymic_staff = patronymic_staff,
                    email_staff = email_staff,
                    id_post = id_post
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Staff.SingleOrDefaultAsync(entity =>
               entity.id_staff == id_staff &&
               entity.lastname_staff == lastname_staff &&
               entity.name_staff == name_staff &&
               entity.patronymic_staff == patronymic_staff &&
               entity.email_staff == email_staff &&
               entity.id_post == id_post));
        }
    }
}
