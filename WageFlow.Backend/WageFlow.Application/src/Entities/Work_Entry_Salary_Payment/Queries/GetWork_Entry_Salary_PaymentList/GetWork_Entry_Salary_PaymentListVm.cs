using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Queries.GetWork_Entry_Salary_PaymentList
{
    public class GetWork_Entry_Salary_PaymentListVm
    {
        public IList<GetWork_Entry_Salary_PaymentLookupDto> Work_Entry_Salary_Payment { get; set; }
    }
}
