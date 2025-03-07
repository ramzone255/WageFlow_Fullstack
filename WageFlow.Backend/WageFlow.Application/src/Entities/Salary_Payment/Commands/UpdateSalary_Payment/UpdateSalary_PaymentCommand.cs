using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment
{
    public class UpdateSalary_PaymentCommand : IRequest
    {
        public int id_salary_payment { get; set; }
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public int id_staff { get; set; }
    }
}
