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

namespace WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList
{
    public class GetWork_TypeListQueryHandler
        : IRequestHandler<GetWork_TypeListQuery, GetWork_TypeListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWork_TypeListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetWork_TypeListVm> Handle(GetWork_TypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Work_Type
                .ProjectTo<GetWork_TypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetWork_TypeListVm { Work_Type = entityQuery };
        }
    }
}
