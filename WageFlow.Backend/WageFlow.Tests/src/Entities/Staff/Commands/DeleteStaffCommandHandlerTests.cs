using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.DeletePayments;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Staff.Common;

namespace WageFlow.Tests.src.Entities.Staff.Commands
{
    public class DeleteStaffCommandHandlerTests : StaffTestCommandBase
    {
        [Fact]
        public async Task DeleteStaffCommandHandler_Success()
        {
            var handler = new DeleteStaffCommandHandler(Context);

            await handler.Handle(new DeleteStaffCommand
            {
                id_staff = StaffContextFactory.id_staff_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Staff.SingleOrDefault(entity =>
            entity.id_staff == StaffContextFactory.id_staff_for_delete));
        }

        [Fact]
        public async Task DeleteStaffCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteStaffCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteStaffCommand
                {
                    id_staff = 5
                },
                CancellationToken.None));
        }
    }
}
