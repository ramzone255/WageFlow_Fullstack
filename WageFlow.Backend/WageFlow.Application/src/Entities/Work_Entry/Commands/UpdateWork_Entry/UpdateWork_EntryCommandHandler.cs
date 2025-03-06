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

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry
{
    public class UpdateWork_EntryCommandHandler :
        IRequestHandler<UpdateWork_EntryCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdateWork_EntryCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateWork_EntryCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Work_Entry.FirstOrDefaultAsync(note =>
                    note.id_work_entry == request.id_work_entry, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Work_Entry), request.id_work_entry);
            }

            entity.quantity_work_entry = request.quantity_work_entry;
            entity.id_staff = request.id_staff;
            entity.id_work_type = request.id_work_type;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
