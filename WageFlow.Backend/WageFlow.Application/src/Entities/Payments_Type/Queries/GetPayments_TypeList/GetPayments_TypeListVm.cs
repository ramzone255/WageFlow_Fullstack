using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList
{
    public class GetPayments_TypeListVm
    {
        public IList<GetPayments_TypeLookupDto> Payments_Type { get; set; }
    }
}
