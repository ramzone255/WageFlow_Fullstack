using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.UpdateWork_Entry_Salary_Payment
{
    public class UpdateWork_Entry_Salary_PaymentCommand : IRequest
    {
        public int id_work_entry_salary_payment { get; set; }
        public int? id_work_entry { get; set; }
        public int? id_salary_payment { get; set; }
    }
}
