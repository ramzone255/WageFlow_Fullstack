using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry
{
    public class CreateWork_EntryCommandHandler
        : IRequestHandler<CreateWork_EntryCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreateWork_EntryCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateWork_EntryCommand request, CancellationToken cancellationToken)
        {
            var work_entry = new Domain.src.Entities.Work_Entry
            {
                quantity_work_entry = request.quantity_work_entry,
                date_work_entry = DateOnly.FromDateTime(DateTime.Now),
                id_staff = request.id_staff,
                id_work_type = request.id_work_type
            };

            await _dbContext.Work_Entry.AddAsync(work_entry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return work_entry.id_work_entry;
        }
    }
}
