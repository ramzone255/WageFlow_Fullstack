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

namespace WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList
{
    public class GetPayments_TypeListQueryHandler
        : IRequestHandler<GetPayments_TypeListQuery, GetPayments_TypeListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPayments_TypeListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetPayments_TypeListVm> Handle(GetPayments_TypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Payments_Type
                .ProjectTo<GetPayments_TypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetPayments_TypeListVm { Payments_Type = entityQuery };
        }
    }
}
