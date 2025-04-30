using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList;
using WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Payments_Type.Common;

namespace WageFlow.Tests.src.Entities.Payments_Type.Queries
{
    [Collection("Payments_TypeQueryCollection")]
    public class GetPayments_TypeListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetPayments_TypeListQueryHandlerTests(Payments_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPayments_TypeListQueryHandler_Success()
        {
            var handler = new GetPayments_TypeListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPayments_TypeListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetPayments_TypeListVm>();
            result.Payments_Type.Count.ShouldBe(4);
        }
    }
}
