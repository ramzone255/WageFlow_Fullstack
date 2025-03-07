using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment
{
    public class CreateWork_Entry_Salary_PaymentCommand : IRequest<int>
    {
        public int? id_work_entry { get; set; }
        public int? id_salary_payment { get; set; }
    }
}
