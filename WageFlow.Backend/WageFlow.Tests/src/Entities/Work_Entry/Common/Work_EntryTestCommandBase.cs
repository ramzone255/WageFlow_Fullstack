using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Work_Entry.Common
{
    public abstract class Work_EntryTestCommandBase : IDisposable
    {
        protected readonly WageFlowDbContext Context;

        public Work_EntryTestCommandBase()
        {
            Context = Work_EntryContextFactory.Create();
        }

        public void Dispose()
        {
            Work_EntryContextFactory.Destroy(Context);
        }
    }
}
