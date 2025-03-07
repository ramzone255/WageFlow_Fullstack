using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.CreateSalary_Payment_Payments
{
    public class CreateSalary_Payment_PaymentsCommandHandler
        : IRequestHandler<CreateSalary_Payment_PaymentsCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreateSalary_Payment_PaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateSalary_Payment_PaymentsCommand request, CancellationToken cancellationToken)
        {
            var salary_payment_payments = new Domain.src.Entities.Salary_Payment_Payments
            {
                id_payments = request.id_payments,
                id_salary_payment = request.id_salary_payment
            };

            await _dbContext.Salary_Payment_Payments.AddAsync(salary_payment_payments, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary_payment_payments.id_salary_payment_payments;
        }
    }
}
