using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Payments.Commands.DeletePayments
{
    public class DeletePaymentsCommandHandler
        : IRequestHandler<DeletePaymentsCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeletePaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeletePaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Payments
                .FindAsync(new object[] { request.id_payments }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments), request.id_payments);
            }
            _dbContext.Payments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
