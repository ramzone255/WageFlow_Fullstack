using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Queries.GetSalary_Payment_PaymentsList
{
    public class GetSalary_Payment_PaymentsListVm
    {
        public IList<GetSalary_Payment_PaymentsLookupDto> Salary_Payment_Payments { get; set; }
    }
}
