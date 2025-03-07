using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.DeleteSalary_Payment
{
    public class DeleteSalary_PaymentCommandHandler
        : IRequestHandler<DeleteSalary_PaymentCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeleteSalary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteSalary_PaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Salary_Payment
                .FindAsync(new object[] { request.id_salary_payment }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Salary_Payment), request.id_salary_payment);
            }
            _dbContext.Salary_Payment.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
