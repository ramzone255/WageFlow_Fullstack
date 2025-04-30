using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;

namespace WageFlow.Tests.src.Entities.Payments.Common
{
    public abstract class PaymentsTestCommandBase : IDisposable
    {
        protected readonly WageFlowDbContext Context;

        public PaymentsTestCommandBase()
        {
            Context = PaymentsContextFactory.Create();
        }

        public void Dispose()
        {
            PaymentsContextFactory.Destroy(Context);
        }
    }
}
