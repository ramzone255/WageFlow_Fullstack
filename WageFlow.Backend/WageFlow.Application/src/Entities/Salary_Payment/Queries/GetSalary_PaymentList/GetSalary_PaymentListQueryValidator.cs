using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList
{
    public class GetSalary_PaymentListQueryValidator
        : AbstractValidator<GetSalary_PaymentListQuery>
    {
        public GetSalary_PaymentListQueryValidator()
        {
            RuleFor(entity => entity.id_salary_payment);
        }
    }
}
