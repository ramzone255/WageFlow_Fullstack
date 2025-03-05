using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler
        : IRequestHandler<CreateStaffCommand, int>
    {
        private readonly IWageFlowDbContext _dbContext;

        public CreateStaffCommandHandler(IWageFlowDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staffs = new Domain.src.Entities.Staff
            {
                name_staff = request.name_staff,
                lastname_staff = request.lastname_staff,
                patronymic_staff = request.patronymic_staff,
                email_staff = request.email_staff,
                id_post = request.id_post
            };

            await _dbContext.Staff.AddAsync(staffs, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return staffs.id_staff;
        }
    }
}
