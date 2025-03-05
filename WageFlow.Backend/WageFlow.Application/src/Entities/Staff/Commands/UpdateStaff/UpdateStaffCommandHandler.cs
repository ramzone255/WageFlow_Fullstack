using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Exceptions;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandHandler :
        IRequestHandler<UpdateStaffCommand>
    {
        private readonly IWageFlowDbContext _dbContext;
        public UpdateStaffCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Staff.FirstOrDefaultAsync(note =>
                    note.id_staff == request.id_staff, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Staff), request.id_staff);
            }

            entity.name_staff = request.name_staff;
            entity.lastname_staff = request.lastname_staff;
            entity.patronymic_staff = request.patronymic_staff;
            entity.email_staff = request.email_staff;
            entity.id_post = request.id_post;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
