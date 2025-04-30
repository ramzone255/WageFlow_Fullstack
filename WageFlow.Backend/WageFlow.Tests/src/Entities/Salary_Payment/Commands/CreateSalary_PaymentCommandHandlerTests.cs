using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Salary_Payment.Common;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Commands
{
    public class CreateSalary_PaymentCommandHandlerTests : Salary_PaymentTestCommandBase
    {
        [Fact]
        public async Task CreateSalary_PaymentCommandHandler_Success()
        {
            var handler = new CreateSalary_PaymentCommandHandler(Context);
            var id_staff = 1;
            var start_date_salary_payment = DateOnly.FromDateTime(DateTime.Now);
            var end_date_salary_payment = DateOnly.FromDateTime(DateTime.Now);

            var id_salary_payment = await handler.Handle(
                new CreateSalary_PaymentCommand
                {
                    start_date_salary_payment = start_date_salary_payment,
                    end_date_salary_payment = end_date_salary_payment,
                    id_staff = id_staff
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Salary_Payment.SingleOrDefaultAsync(entity =>
               entity.id_salary_payment == id_salary_payment &&
               entity.start_date_salary_payment == start_date_salary_payment &&
               entity.end_date_salary_payment == end_date_salary_payment &&
               entity.id_staff == id_staff));
        }
    }
}
