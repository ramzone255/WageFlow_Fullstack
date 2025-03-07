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

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.UpdateSalary_Payment_Payments
{
    public class UpdateSalary_Payment_PaymentsCommandHandler :
        IRequestHandler<UpdateSalary_Payment_PaymentsCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdateSalary_Payment_PaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateSalary_Payment_PaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Salary_Payment_Payments.FirstOrDefaultAsync(note =>
                    note.id_salary_payment_payments == request.id_salary_payment_payments, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Salary_Payment_Payments), request.id_salary_payment_payments);
            }

            entity.id_salary_payment = request.id_salary_payment;
            entity.id_payments = request.id_payments;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
