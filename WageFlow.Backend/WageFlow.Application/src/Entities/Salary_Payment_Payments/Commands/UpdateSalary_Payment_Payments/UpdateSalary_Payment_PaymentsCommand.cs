using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.UpdateSalary_Payment_Payments
{
    public class UpdateSalary_Payment_PaymentsCommand : IRequest
    {
        public int id_salary_payment_payments { get; set; }
        public int? id_payments { get; set; }
        public int? id_salary_payment { get; set; }
    }
}
