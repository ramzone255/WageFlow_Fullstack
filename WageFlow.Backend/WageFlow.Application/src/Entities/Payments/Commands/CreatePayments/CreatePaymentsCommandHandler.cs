using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommandHandler
        : IRequestHandler<CreatePaymentsCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreatePaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreatePaymentsCommand request, CancellationToken cancellationToken)
        {
            var payments = new Domain.src.Entities.Payments
            {
                amount_payments = request.amount_payments,
                comment = request.comment,
                date_payments = DateOnly.FromDateTime(DateTime.Now),
                id_staff = request.id_staff,
                id_payments_type = request.id_payments_type
            };

            await _dbContext.Payments.AddAsync(payments, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payments.id_payments;
        }
    }
}
