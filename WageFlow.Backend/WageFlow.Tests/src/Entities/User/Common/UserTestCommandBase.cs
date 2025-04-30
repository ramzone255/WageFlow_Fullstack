using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Persistence.src.Data;
using WageFlow.Tests.src.Entities.Payments.Common;

namespace WageFlow.Tests.src.Entities.User.Common
{
    public abstract class UserTestCommandBase : IDisposable
    {
        protected readonly WageFlowDbContext Context;

        public UserTestCommandBase()
        {
            Context = UserContextFactory.Create();
        }

        public void Dispose()
        {
            UserContextFactory.Destroy(Context);
        }
    }
}
