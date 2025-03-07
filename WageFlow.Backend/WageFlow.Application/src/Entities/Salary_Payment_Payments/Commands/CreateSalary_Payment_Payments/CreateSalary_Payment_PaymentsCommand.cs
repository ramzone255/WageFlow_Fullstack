using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.CreateSalary_Payment_Payments
{
    public class CreateSalary_Payment_PaymentsCommand : IRequest<int>
    {
        public int? id_payments { get; set; }
        public int? id_salary_payment { get; set; }
    }
}
