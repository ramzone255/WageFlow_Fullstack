using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Post.Common
{
    public class PostContextFactory
    {

        public static WageFlowDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WageFlowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WageFlowDbContext(options);
            context.Database.EnsureCreated();

            context.Post.AddRange(
                new Domain.src.Entities.Post
                {
                    id_post = 1,
                    name_post = "Имя 1"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 2,
                    name_post = "Имя 2"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 3,
                    name_post = "Имя 3"
                },

                new Domain.src.Entities.Post
                {
                    id_post = 4,
                    name_post = "Имя 4"
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(WageFlowDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
