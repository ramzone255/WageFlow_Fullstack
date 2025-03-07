using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.DeleteSalary_Payment_Payments
{
    public class DeleteSalary_Payment_PaymentsCommand : IRequest
    {
        public int id_salary_payment_payments { get; set; }
    }
}
