using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Payments.Commands
{
    public class CreatePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task CreatePaymentsCommandHandler_Success()
        {
            var handler = new CreatePaymentsCommandHandler(Context);
            var id_staff = 1;
            var amount_payments = 1;
            var comment = "Комментарий 1";
            var id_payments_type = 1;

            var id_payments = await handler.Handle(
                new CreatePaymentsCommand
                {
                    amount_payments = amount_payments,
                    comment = comment,
                    id_staff = id_staff,
                    id_payments_type = id_payments_type
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Payments.SingleOrDefaultAsync(entity =>
               entity.id_payments == id_payments &&
               entity.amount_payments == amount_payments &&
               entity.comment == comment &&
               entity.id_staff == id_staff &&
               entity.id_payments_type == id_payments_type));
        }
    }
}
