using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Domain.src.Entities;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Payments_Type.Common
{
    public class Payments_TypeContextFactory
    {
        public static WageFlowDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WageFlowDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WageFlowDbContext(options);
            context.Database.EnsureCreated();

            context.Payments_Type.AddRange(
                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 1,
                    name_payments_type = "Имя 1"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 2,
                    name_payments_type = "Имя 2"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 3,
                    name_payments_type = "Имя 3"
                },

                new Domain.src.Entities.Payments_Type
                {
                    id_payments_type = 4,
                    name_payments_type = "Имя 4"
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
