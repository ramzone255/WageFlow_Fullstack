using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Interfaces;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Payments_Type.Common
{
    public class Payments_TypeQueryTestFixture : IDisposable
    {
        public WageFlowDbContext Context;
        public IMapper Mapper;

        public Payments_TypeQueryTestFixture()
        {
            Context = Payments_TypeContextFactory.Create();
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
            Payments_TypeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Payments_TypeQueryCollection")]
    public class QueryCollection : ICollectionFixture<Payments_TypeQueryTestFixture> { }
}
