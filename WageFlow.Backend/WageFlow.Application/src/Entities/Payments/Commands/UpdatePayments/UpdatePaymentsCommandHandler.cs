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

namespace WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommandHandler :
        IRequestHandler<UpdatePaymentsCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdatePaymentsCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdatePaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Payments.FirstOrDefaultAsync(note =>
                    note.id_payments == request.id_payments, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments), request.id_payments);
            }

            entity.amount_payments = request.amount_payments;
            entity.comment = request.comment;
            entity.id_staff = request.id_staff;
            entity.id_payments_type = request.id_payments_type;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
