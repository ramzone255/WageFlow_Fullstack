using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Salary_Payment.Common;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Commands
{
    public class UpdateSalary_PaymentCommandHandlerTests : Salary_PaymentTestCommandBase
    {
        [Fact]
        public async Task UpdateSalary_PaymentCommandHandler_Success()
        {
            var handler = new UpdateSalary_PaymentCommandHandler(Context);
            var updatedStart_date_salary_payment = DateOnly.FromDateTime(DateTime.Now);
            var updatedEnd_date_salary_payment = DateOnly.FromDateTime(DateTime.Now);
            var updatedId_staff = 1;

            await handler.Handle(new UpdateSalary_PaymentCommand
            {
                id_salary_payment = Salary_PaymentContextFactory.id_salary_payment_for_update,
                start_date_salary_payment = updatedStart_date_salary_payment,
                end_date_salary_payment = updatedEnd_date_salary_payment,
                id_staff = updatedId_staff
            }, CancellationToken.None);

            Assert.NotNull(await Context.Salary_Payment.SingleOrDefaultAsync(entity =>
            entity.id_salary_payment == Salary_PaymentContextFactory.id_salary_payment_for_update &&
            entity.start_date_salary_payment == updatedStart_date_salary_payment &&
            entity.end_date_salary_payment == updatedEnd_date_salary_payment &&
            entity.id_staff == updatedId_staff));
        }

        [Fact]
        public async Task UpdateSalary_PaymentCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateSalary_PaymentCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateSalary_PaymentCommand
                {
                    id_salary_payment = 5
                },
                CancellationToken.None));
        }
    }
}
