using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Interfaces;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments_Type.Common;

namespace WageFlow.Tests.src.Entities.Work_Type.Common
{
    public class Work_TypeQueryTestFixture : IDisposable
    {
        public WageFlowDbContext Context;
        public IMapper Mapper;

        public Work_TypeQueryTestFixture()
        {
            Context = Work_TypeContextFactory.Create();
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
            Work_TypeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Work_TypeQueryCollection")]
    public class QueryCollection : ICollectionFixture<Work_TypeQueryTestFixture> { }
}
