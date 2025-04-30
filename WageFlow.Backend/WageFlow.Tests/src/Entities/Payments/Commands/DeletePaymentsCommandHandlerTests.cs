﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.DeletePayments;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Payments.Commands
{
    public class DeletePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task DeletePaymentsCommandHandler_Success()
        {
            var handler = new DeletePaymentsCommandHandler(Context);

            await handler.Handle(new DeletePaymentsCommand
            {
                id_payments = PaymentsContextFactory.id_payments_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Payments.SingleOrDefault(entity =>
            entity.id_payments == PaymentsContextFactory.id_payments_for_delete));
        }

        [Fact]
        public async Task DeletePaymentsCommandHandler_FailOnWrongId()
        {
            var handler = new DeletePaymentsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePaymentsCommand
                {
                    id_payments = 5
                },
                CancellationToken.None));
        }
    }
}
