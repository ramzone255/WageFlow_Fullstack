using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Persistence.src.Data
{
    public class DbInitializer
    {
        public static void Initialize(WageFlowDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
