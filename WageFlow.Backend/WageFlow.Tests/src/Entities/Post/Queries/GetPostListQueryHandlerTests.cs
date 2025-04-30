using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList;
using WageFlow.Application.src.Entities.Post.Queries.GetPostList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments_Type.Common;
using WageFlow.Tests.src.Entities.Post.Common;

namespace WageFlow.Tests.src.Entities.Post.Queries
{
    [Collection("PostQueryCollection")]
    public class GetPostListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetPostListQueryHandlerTests(PostQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPostListQueryHandler_Success()
        {
            var handler = new GetPostListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPostListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetPostListVm>();
            result.Post.Count.ShouldBe(4);
        }
    }
}
