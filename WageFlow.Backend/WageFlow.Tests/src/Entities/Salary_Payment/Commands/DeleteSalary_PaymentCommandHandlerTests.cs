using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.DeletePayments;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.DeleteSalary_Payment;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Salary_Payment.Common;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Commands
{
    public class DeleteSalary_PaymentCommandHandlerTests : Salary_PaymentTestCommandBase
    {
        [Fact]
        public async Task DeleteSalary_PaymentCommandHandler_Success()
        {
            var handler = new DeleteSalary_PaymentCommandHandler(Context);

            await handler.Handle(new DeleteSalary_PaymentCommand
            {
                id_salary_payment = Salary_PaymentContextFactory.id_salary_payment_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Salary_Payment.SingleOrDefault(entity =>
            entity.id_salary_payment == Salary_PaymentContextFactory.id_salary_payment_for_delete));
        }

        [Fact]
        public async Task DeleteSalary_PaymentCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteSalary_PaymentCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteSalary_PaymentCommand
                {
                    id_salary_payment = 5
                },
                CancellationToken.None));
        }
    }
}
