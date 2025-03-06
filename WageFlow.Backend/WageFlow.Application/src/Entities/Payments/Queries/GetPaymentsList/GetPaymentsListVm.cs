using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListVm
    {
        public IList<GetPaymentsLookupDto> Payments { get; set; }
    }
}
