using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Interfaces;
using WageFlow.Domain.src.Entities;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment
{
    public class CreateSalary_PaymentCommandHandler
        : IRequestHandler<CreateSalary_PaymentCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreateSalary_PaymentCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateSalary_PaymentCommand request, CancellationToken cancellationToken)
        {
            float totalSalary = await CalculateSalary(request.id_staff, request.start_date_salary_payment, request.end_date_salary_payment);

            var salary_payment = new Domain.src.Entities.Salary_Payment
            {
                amount_salary_payment = totalSalary,
                start_date_salary_payment = request.start_date_salary_payment,
                end_date_salary_payment = request.end_date_salary_payment,
                date_salary_payment = DateOnly.FromDateTime(DateTime.Now),
                id_staff = request.id_staff
            };

            await _dbContext.Salary_Payment.AddAsync(salary_payment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary_payment.id_salary_payment;

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
