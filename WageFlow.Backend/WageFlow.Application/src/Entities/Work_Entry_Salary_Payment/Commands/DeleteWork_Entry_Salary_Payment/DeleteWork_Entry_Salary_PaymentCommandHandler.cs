using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.DeleteWork_Entry_Salary_Payment
{
    public class DeleteWork_Entry_Salary_PaymentCommandHandler
        : IRequestHandler<DeleteWork_Entry_Salary_PaymentCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeleteWork_Entry_Salary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteWork_Entry_Salary_PaymentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Work_Entry_Salary_Payment
                .FindAsync(new object[] { request.id_work_entry_salary_payment }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Work_Entry_Salary_Payment), request.id_work_entry_salary_payment);
            }
            _dbContext.Work_Entry_Salary_Payment.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
