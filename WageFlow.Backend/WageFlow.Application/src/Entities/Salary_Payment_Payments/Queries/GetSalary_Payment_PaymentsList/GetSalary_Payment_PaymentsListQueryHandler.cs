using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Queries.GetSalary_Payment_PaymentsList
{
    public class GetSalary_Payment_PaymentsListQueryHandler
        : IRequestHandler<GetSalary_Payment_PaymentsListQuery, GetSalary_Payment_PaymentsListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSalary_Payment_PaymentsListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetSalary_Payment_PaymentsListVm> Handle(GetSalary_Payment_PaymentsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Salary_Payment_Payments
                .ProjectTo<GetSalary_Payment_PaymentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetSalary_Payment_PaymentsListVm { Salary_Payment_Payments = entityQuery };
        }
    }
}
