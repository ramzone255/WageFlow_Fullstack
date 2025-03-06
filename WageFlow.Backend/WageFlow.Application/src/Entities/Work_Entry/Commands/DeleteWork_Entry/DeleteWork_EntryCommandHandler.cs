using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.DeleteWork_Entry
{
    public class DeleteWork_EntryCommandHandler
        : IRequestHandler<DeleteWork_EntryCommand>
    {
        private readonly IWageFlowDbContext _dbContext;

        public DeleteWork_EntryCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteWork_EntryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Work_Entry
                .FindAsync(new object[] { request.id_work_entry }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Work_Entry), request.id_work_entry);
            }
            _dbContext.Work_Entry.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
