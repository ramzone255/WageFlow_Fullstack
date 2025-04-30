using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.Salary_Payment.Common
{
    public abstract class Salary_PaymentTestCommandBase : IDisposable
    {
        protected readonly WageFlowDbContext Context;

        public Salary_PaymentTestCommandBase()
        {
            Context = Salary_PaymentContextFactory.Create();
        }

        public void Dispose()
        {
            Salary_PaymentContextFactory.Destroy(Context);
        }
    }
}
