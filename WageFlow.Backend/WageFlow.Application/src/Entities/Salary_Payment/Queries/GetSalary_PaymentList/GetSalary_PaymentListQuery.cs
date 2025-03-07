using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList
{
    public class GetSalary_PaymentListQuery : IRequest<GetSalary_PaymentListVm>
    {
        public int id_salary_payment { get; set; }
    }
}
