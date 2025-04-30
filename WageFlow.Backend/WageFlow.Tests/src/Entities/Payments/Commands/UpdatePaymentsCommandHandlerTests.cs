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

namespace WageFlow.Tests.src.Entities.Payments.Commands
{
    public class UpdatePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task UpdatePaymentsCommandHandler_Success()
        {
            var handler = new UpdatePaymentsCommandHandler(Context);
            var updatedAmount_payments = 1;
            var updatedComment = "Орлов";
            var updatedId_staff = 1;
            var updatedId_payments_type = 1;

            await handler.Handle(new UpdatePaymentsCommand
            {
                id_payments = PaymentsContextFactory.id_payments_for_update,
                amount_payments = updatedAmount_payments,
                comment = updatedComment,
                id_staff = updatedId_staff,
                id_payments_type = updatedId_payments_type
            }, CancellationToken.None);

            Assert.NotNull(await Context.Payments.SingleOrDefaultAsync(entity =>
            entity.id_payments == PaymentsContextFactory.id_payments_for_update &&
            entity.amount_payments == updatedAmount_payments &&
            entity.comment == updatedComment &&
            entity.id_staff == updatedId_staff &&
            entity.id_payments_type == updatedId_payments_type));
        }

        [Fact]
        public async Task UpdatePaymentsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdatePaymentsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePaymentsCommand
                {
                    id_payments = 5
                },
                CancellationToken.None));
        }
    }
}
