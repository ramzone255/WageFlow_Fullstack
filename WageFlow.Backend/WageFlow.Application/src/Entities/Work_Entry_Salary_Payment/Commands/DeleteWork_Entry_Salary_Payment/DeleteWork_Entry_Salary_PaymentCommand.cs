using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.DeleteWork_Entry_Salary_Payment
{
    public class DeleteWork_Entry_Salary_PaymentCommand : IRequest
    {
        public int id_work_entry_salary_payment { get; set; }
    }
}
