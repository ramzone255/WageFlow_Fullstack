using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.DeleteSalary_Payment_Payments
{
    public class DeleteSalary_Payment_PaymentsCommandHandler
        : IRequestHandler<DeleteSalary_Payment_PaymentsCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeleteSalary_Payment_PaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteSalary_Payment_PaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Salary_Payment_Payments
                .FindAsync(new object[] { request.id_salary_payment_payments }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Salary_Payment_Payments), request.id_salary_payment_payments);
            }
            _dbContext.Salary_Payment_Payments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
