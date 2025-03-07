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

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment
{
    public class UpdateSalary_PaymentCommandHandler :
        IRequestHandler<UpdateSalary_PaymentCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdateSalary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateSalary_PaymentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Salary_Payment.FirstOrDefaultAsync(note =>
                    note.id_salary_payment == request.id_salary_payment, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Salary_Payment), request.id_salary_payment);
            }

            float totalSalary = await CalculateSalary(request.id_staff, request.start_date_salary_payment, request.end_date_salary_payment);

            entity.amount_salary_payment = totalSalary;
            entity.start_date_salary_payment = request.start_date_salary_payment;
            entity.end_date_salary_payment = request.end_date_salary_payment;
            entity.id_staff = request.id_staff;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }

        private async Task<float> CalculateSalary(int id_staff, DateOnly start_date_salary_payment, DateOnly end_date_salary_payment)
        {
            float workAmount = await _dbContext.Work_Entry
                .Where(w => w.id_staff == id_staff
                && w.date_work_entry >= start_date_salary_payment
                && w.date_work_entry <= end_date_salary_payment)
                .SumAsync(w => w.quantity_work_entry * w.Work_Type.amount_work_type);

            float plus = await _dbContext.Payments
                .Where(p => p.id_staff == id_staff
                && p.date_payments >= start_date_salary_payment
                && p.date_payments <= end_date_salary_payment
                && p.Payments_Type.id_payments_type == 1)
                .SumAsync(p => p.amount_payments);

            float minus = await _dbContext.Payments
                .Where(p => p.id_staff == id_staff
                && p.date_payments >= start_date_salary_payment
                && p.date_payments <= end_date_salary_payment
                && p.Payments_Type.id_payments_type == 2)
                .SumAsync(p => p.amount_payments);

            return workAmount + plus - minus;
        }
    }
}
