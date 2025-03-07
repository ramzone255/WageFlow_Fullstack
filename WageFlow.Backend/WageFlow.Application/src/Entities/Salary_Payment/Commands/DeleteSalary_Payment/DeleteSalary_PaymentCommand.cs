using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Commands.DeleteSalary_Payment
{
    public class DeleteSalary_PaymentCommand : IRequest
    {
        public int id_salary_payment { get; set; }
    }
}
