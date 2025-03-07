using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.UpdateWork_Entry_Salary_Payment
{
    public class UpdateWork_Entry_Salary_PaymentCommandHandler :
        IRequestHandler<UpdateWork_Entry_Salary_PaymentCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdateWork_Entry_Salary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateWork_Entry_Salary_PaymentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Work_Entry_Salary_Payment.FirstOrDefaultAsync(note =>
                    note.id_work_entry_salary_payment == request.id_work_entry_salary_payment, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Work_Entry_Salary_Payment), request.id_work_entry_salary_payment);
            }

            entity.id_salary_payment = request.id_salary_payment;
            entity.id_work_entry = request.id_work_entry;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
