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

namespace WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListQueryHandler
        : IRequestHandler<GetPaymentsListQuery, GetPaymentsListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPaymentsListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetPaymentsListVm> Handle(GetPaymentsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Payments
                .ProjectTo<GetPaymentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetPaymentsListVm { Payments = entityQuery };
        }
    }
}
