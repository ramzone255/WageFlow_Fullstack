using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList
{
    public class GetWork_EntryListQueryValidator
        : AbstractValidator<GetWork_EntryListQuery>
    {
        public GetWork_EntryListQueryValidator()
        {
            RuleFor(entity => entity.id_work_entry);
        }
    }
}
