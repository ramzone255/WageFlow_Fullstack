using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Interfaces;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Payments.Common
{
    public class PaymentsQueryTestFixture : IDisposable
    {
        public WageFlowDbContext Context;
        public IMapper Mapper;

        public PaymentsQueryTestFixture()
        {
            Context = PaymentsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.ShouldMapMethod = (m => false);
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IWageFlowDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            PaymentsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("PaymentsQueryCollection")]
    public class QueryCollection : ICollectionFixture<PaymentsQueryTestFixture> { }
}
