using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Staff.Common
{
    public abstract class StaffTestCommandBase : IDisposable
    {
        protected readonly WageFlowDbContext Context;

        public StaffTestCommandBase()
        {
            Context = StaffContextFactory.Create();
        }

        public void Dispose()
        {
            StaffContextFactory.Destroy(Context);
        }
    }
}
