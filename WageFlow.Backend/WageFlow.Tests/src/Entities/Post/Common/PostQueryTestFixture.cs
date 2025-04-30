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

namespace WageFlow.Tests.src.Entities.Post.Common
{
    public class PostQueryTestFixture : IDisposable
    {
        public WageFlowDbContext Context;
        public IMapper Mapper;

        public PostQueryTestFixture()
        {
            Context = PostContextFactory.Create();
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
            PostContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("PostQueryCollection")]
    public class QueryCollection : ICollectionFixture<PostQueryTestFixture> { }
}
