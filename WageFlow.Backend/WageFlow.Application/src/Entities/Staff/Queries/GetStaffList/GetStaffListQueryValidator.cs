using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Queries.GetStaffList
{
    public class GetStaffListQueryValidator : AbstractValidator<GetStaffListQuery>
    {
        public GetStaffListQueryValidator()
        {
            RuleFor(entity => entity.id_staff);
        }
    }
}
