using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff
{
    public class DeleteStaffCommandHandler
        : IRequestHandler<DeleteStaffCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeleteStaffCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Staff
                .FindAsync(new object[] { request.id_staff }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Staff), request.id_staff);
            }
            _dbContext.Staff.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
