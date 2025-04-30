using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Payments.Queries
{
    [Collection("PaymentsQueryCollection")]
    public class GetPaymentsListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetPaymentsListQueryHandlerTests(PaymentsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPaymentsListQueryHandler_Success()
        {
            var handler = new GetPaymentsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPaymentsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetPaymentsListVm>();
            result.Payments.Count.ShouldBe(4);
        }
    }
}
