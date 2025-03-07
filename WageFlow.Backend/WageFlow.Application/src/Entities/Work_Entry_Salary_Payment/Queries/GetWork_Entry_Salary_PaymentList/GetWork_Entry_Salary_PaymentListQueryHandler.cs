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

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Queries.GetWork_Entry_Salary_PaymentList
{
    public class GetWork_Entry_Salary_PaymentListQueryHandler
        : IRequestHandler<GetWork_Entry_Salary_PaymentListQuery, GetWork_Entry_Salary_PaymentListVm>
    {
        private readonly IWageFlowDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWork_Entry_Salary_PaymentListQueryHandler(IWageFlowDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetWork_Entry_Salary_PaymentListVm> Handle(GetWork_Entry_Salary_PaymentListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Work_Entry_Salary_Payment
                .ProjectTo<GetWork_Entry_Salary_PaymentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetWork_Entry_Salary_PaymentListVm { Work_Entry_Salary_Payment = entityQuery };
        }
    }
}
