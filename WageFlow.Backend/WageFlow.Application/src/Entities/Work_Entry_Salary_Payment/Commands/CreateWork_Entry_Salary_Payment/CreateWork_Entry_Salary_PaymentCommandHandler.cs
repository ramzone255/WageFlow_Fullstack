using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment
{
    public class CreateWork_Entry_Salary_PaymentCommandHandler
        : IRequestHandler<CreateWork_Entry_Salary_PaymentCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreateWork_Entry_Salary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateWork_Entry_Salary_PaymentCommand request, CancellationToken cancellationToken)
        {
            var work_entry_salary_payments = new Domain.src.Entities.Work_Entry_Salary_Payment
            {
                id_salary_payment = request.id_salary_payment,
                id_work_entry = request.id_work_entry
            };

            await _dbContext.Work_Entry_Salary_Payment.AddAsync(work_entry_salary_payments, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return work_entry_salary_payments.id_work_entry_salary_payment;
        }
    }
}
