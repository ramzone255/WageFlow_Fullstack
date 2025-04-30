using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList;
using WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments_Type.Common;
using WageFlow.Tests.src.Entities.Work_Type.Common;

namespace WageFlow.Tests.src.Entities.Work_Type.Queries
{
    [Collection("Work_TypeQueryCollection")]
    public class GetWork_TypeListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetWork_TypeListQueryHandlerTests(Work_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetWork_TypeListQueryHandler_Success()
        {
            var handler = new GetWork_TypeListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetWork_TypeListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetWork_TypeListVm>();
            result.Work_Type.Count.ShouldBe(4);
        }
    }
}
