using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Queries.GetSalary_Payment_PaymentsList
{
    public class GetSalary_Payment_PaymentsListQueryValidator
        : AbstractValidator<GetSalary_Payment_PaymentsListQuery>
    {
        public GetSalary_Payment_PaymentsListQueryValidator()
        {
            RuleFor(entity => entity.id_salary_payment_payments);
        }
    }
}
