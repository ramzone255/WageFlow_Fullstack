using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Staff.Common;

namespace WageFlow.Tests.src.Entities.Staff.Commands
{
    public class UpdateStaffCommandHandlerTests : StaffTestCommandBase
    {
        [Fact]
        public async Task UpdateStaffCommandHandler_Success()
        {
            var handler = new UpdateStaffCommandHandler(Context);
            var updatedLastname_staff = "Фамилия 1";
            var updatedName_staff = "Имя 1";
            var updatedPatronymic_staff = "Отчество 1";
            var updatedEmail_staff = "Почта 1";
            var updatedId_post = 1;

            await handler.Handle(new UpdateStaffCommand
            {
                id_staff = StaffContextFactory.id_staff_for_update,
                lastname_staff = updatedLastname_staff,
                name_staff = updatedName_staff,
                patronymic_staff = updatedPatronymic_staff,
                email_staff = updatedEmail_staff,
                id_post = updatedId_post
            }, CancellationToken.None);

            Assert.NotNull(await Context.Staff.SingleOrDefaultAsync(entity =>
            entity.id_staff == StaffContextFactory.id_staff_for_update &&
            entity.lastname_staff == updatedLastname_staff &&
            entity.name_staff == updatedName_staff &&
            entity.patronymic_staff == updatedPatronymic_staff &&
            entity.email_staff == updatedEmail_staff &&
            entity.id_post == updatedId_post));
        }

        [Fact]
        public async Task UpdateStaffCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateStaffCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateStaffCommand
                {
                    id_staff = 5
                },
                CancellationToken.None));
        }
    }
}
