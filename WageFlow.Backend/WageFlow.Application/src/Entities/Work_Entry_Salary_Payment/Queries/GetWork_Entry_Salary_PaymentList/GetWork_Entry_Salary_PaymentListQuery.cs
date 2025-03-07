using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Queries.GetWork_Entry_Salary_PaymentList
{
    public class GetWork_Entry_Salary_PaymentListQuery
        : IRequest<GetWork_Entry_Salary_PaymentListVm>
    {
        public int id_work_entry_salary_payment { get; set; }
    }
}
