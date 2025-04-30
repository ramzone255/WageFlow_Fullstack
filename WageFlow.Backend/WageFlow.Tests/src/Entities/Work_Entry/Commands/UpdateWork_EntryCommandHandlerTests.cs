using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments;
using WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Work_Entry.Common;

namespace WageFlow.Tests.src.Entities.Work_Entry.Commands
{
    public class UpdateWork_EntryCommandHandlerTests : Work_EntryTestCommandBase
    {
        [Fact]
        public async Task UpdateWork_EntryCommandHandler_Success()
        {
            var handler = new UpdateWork_EntryCommandHandler(Context);
            var updatedQuantity_work_entry = 1;
            var updatedId_staff = 1;
            var updatedId_work_type = 1;

            await handler.Handle(new UpdateWork_EntryCommand
            {
                id_work_entry = Work_EntryContextFactory.id_work_entry_for_update,
                quantity_work_entry = updatedQuantity_work_entry,
                id_staff = updatedId_staff,
                id_work_type = updatedId_work_type
            }, CancellationToken.None);

            Assert.NotNull(await Context.Work_Entry.SingleOrDefaultAsync(entity =>
            entity.id_work_entry == Work_EntryContextFactory.id_work_entry_for_update &&
            entity.quantity_work_entry == updatedQuantity_work_entry &&
            entity.id_staff == updatedId_staff &&
            entity.id_work_type == updatedId_work_type));
        }

        [Fact]
        public async Task UpdateWork_EntryCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateWork_EntryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateWork_EntryCommand
                {
                    id_work_entry = 5
                },
                CancellationToken.None));
        }
    }
}
