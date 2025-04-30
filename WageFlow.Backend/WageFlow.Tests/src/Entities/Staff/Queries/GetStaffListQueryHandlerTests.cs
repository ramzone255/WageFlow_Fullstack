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
using WageFlow.Tests.src.Entities.Staff.Common;

namespace WageFlow.Tests.src.Entities.Staff.Queries
{
    [Collection("StaffQueryCollection")]
    public class GetStaffListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetStaffListQueryHandlerTests(StaffQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetStaffListQueryHandler_Success()
        {
            var handler = new GetStaffListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetStaffListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetStaffListVm>();
            result.Staff.Count.ShouldBe(4);
        }
    }
}
