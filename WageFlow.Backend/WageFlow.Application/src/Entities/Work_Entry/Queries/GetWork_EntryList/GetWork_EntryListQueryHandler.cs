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

namespace WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList
{
    public class GetWork_EntryListQueryHandler
        : IRequestHandler<GetWork_EntryListQuery, GetWork_EntryListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWork_EntryListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetWork_EntryListVm> Handle(GetWork_EntryListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Work_Entry
                .ProjectTo<GetWork_EntryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetWork_EntryListVm { Work_Entry = entityQuery };
        }
    }
}
