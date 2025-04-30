using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList;
using WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;
using WageFlow.Tests.src.Entities.Salary_Payment.Common;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Queries
{
    [Collection("Salary_PaymentQueryCollection")]
    public class GetSalary_PaymentListQueryHandlerTests
    {
        private readonly WageFlowDbContext Context;
        private readonly IMapper Mapper;

        public GetSalary_PaymentListQueryHandlerTests(Salary_PaymentQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetSalary_PaymentListQueryHandler_Success()
        {
            var handler = new GetSalary_PaymentListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetSalary_PaymentListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<GetSalary_PaymentListVm>();
            result.Salary_Payment.Count.ShouldBe(4);
        }
    }
}
