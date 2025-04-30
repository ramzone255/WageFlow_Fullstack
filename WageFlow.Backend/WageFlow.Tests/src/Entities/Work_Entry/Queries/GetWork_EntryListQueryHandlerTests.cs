using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList;
using WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Work_Entry.Common;

namespace WageFlow.Tests.src.Entities.Work_Entry.Queries
{
    [Collection("Work_EntryQueryCollection")]
    public class GetWork_EntryListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetWork_EntryListQueryHandlerTests(Work_EntryQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetWork_EntryListQueryHandler_Success()
        {
            var handler = new GetWork_EntryListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetWork_EntryListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetWork_EntryListVm>();
            result.Work_Entry.Count.ShouldBe(4);
        }
    }
}
