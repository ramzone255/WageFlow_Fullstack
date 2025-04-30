using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Work_Type.Common
{
    public class Work_TypeContextFactory
    {
        public static WageFlowDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WageFlowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WageFlowDbContext(options);
            context.Database.EnsureCreated();

            context.Work_Type.AddRange(
                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 1,
                    name_work_type = "Имя 1",
                    amount_work_type = 1
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 2,
                    name_work_type = "Имя 2",
                    amount_work_type = 2
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 3,
                    name_work_type = "Имя 3",
                    amount_work_type = 3
                },

                new Domain.src.Entities.Work_Type
                {
                    id_work_type = 4,
                    name_work_type = "Имя 4",
                    amount_work_type = 4
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
