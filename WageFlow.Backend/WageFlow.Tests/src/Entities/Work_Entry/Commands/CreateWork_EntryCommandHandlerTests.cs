using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Work_Entry.Common;

namespace WageFlow.Tests.src.Entities.Work_Entry.Commands
{
    public class CreateWork_EntryCommandHandlerTests : Work_EntryTestCommandBase
    {
        [Fact]
        public async Task CreateWork_EntryCommandHandler_Success()
        {
            var handler = new CreateWork_EntryCommandHandler(Context);
            var quantity_work_entry = 1;
            var id_staff = 1;
            var id_work_type = 1;

            var id_work_entry = await handler.Handle(
                new CreateWork_EntryCommand
                {
                    quantity_work_entry = quantity_work_entry,
                    id_staff = id_staff,
                    id_work_type = id_work_type
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Work_Entry.SingleOrDefaultAsync(entity =>
               entity.id_work_entry == id_work_entry &&
               entity.quantity_work_entry == quantity_work_entry &&
               entity.id_staff == id_staff &&
               entity.id_work_type == id_work_type));
        }
    }
}
