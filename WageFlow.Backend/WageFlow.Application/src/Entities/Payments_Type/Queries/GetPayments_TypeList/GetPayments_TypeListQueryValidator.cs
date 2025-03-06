using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList
{
    public class GetPayments_TypeListQueryValidator
        : AbstractValidator<GetPayments_TypeListQuery>
    {
        public GetPayments_TypeListQueryValidator()
        {
            RuleFor(entity => entity.id_payments_type);
        }
    }
}
