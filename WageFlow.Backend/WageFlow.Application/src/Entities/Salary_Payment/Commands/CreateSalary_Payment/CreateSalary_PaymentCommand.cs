using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment
{
    public class CreateSalary_PaymentCommand : IRequest<int>
    {
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public int id_staff { get; set; }
    }
}
