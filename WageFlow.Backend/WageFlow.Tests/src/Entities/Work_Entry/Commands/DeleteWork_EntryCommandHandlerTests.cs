using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.DeletePayments;
using WageFlow.Application.src.Entities.Work_Entry.Commands.DeleteWork_Entry;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Work_Entry.Common;

namespace WageFlow.Tests.src.Entities.Work_Entry.Commands
{
    public class DeleteWork_EntryCommandHandlerTests : Work_EntryTestCommandBase
    {
        [Fact]
        public async Task DeleteWork_EntryCommandHandler_Success()
        {
            var handler = new DeleteWork_EntryCommandHandler(Context);

            await handler.Handle(new DeleteWork_EntryCommand
            {
                id_work_entry = Work_EntryContextFactory.id_work_entry_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Work_Entry.SingleOrDefault(entity =>
            entity.id_work_entry == Work_EntryContextFactory.id_work_entry_for_delete));
        }

        [Fact]
        public async Task DeleteWork_EntryCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteWork_EntryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteWork_EntryCommand
                {
                    id_work_entry = 5
                },
                CancellationToken.None));
        }
    }
}
