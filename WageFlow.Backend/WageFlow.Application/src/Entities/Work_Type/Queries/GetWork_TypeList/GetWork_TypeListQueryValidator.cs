using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList
{
    public class GetWork_TypeListQueryValidator
        : AbstractValidator<GetWork_TypeListQuery>
    {
        public GetWork_TypeListQueryValidator()
        {
            RuleFor(entity => entity.id_work_type);
        }
    }
}
