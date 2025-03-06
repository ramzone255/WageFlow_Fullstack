using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListQueryValidator
        : AbstractValidator<GetPaymentsListQuery>
    {
        public GetPaymentsListQueryValidator()
        {
            RuleFor(entity => entity.id_payments);
        }
    }
}
