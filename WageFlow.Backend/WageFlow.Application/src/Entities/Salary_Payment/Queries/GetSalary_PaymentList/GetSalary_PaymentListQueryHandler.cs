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

namespace WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList
{
    public class GetSalary_PaymentListQueryHandler
        : IRequestHandler<GetSalary_PaymentListQuery, GetSalary_PaymentListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSalary_PaymentListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetSalary_PaymentListVm> Handle(GetSalary_PaymentListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Salary_Payment
                .ProjectTo<GetSalary_PaymentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetSalary_PaymentListVm { Salary_Payment = entityQuery };
        }
    }
}
