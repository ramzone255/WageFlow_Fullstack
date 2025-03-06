using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry
{
    public class CreateWork_EntryCommandValidator
        : AbstractValidator<CreateWork_EntryCommand>
    {
        public CreateWork_EntryCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.quantity_work_entry).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.date_work_entry).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_staff).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_work_type).NotEmpty();
        }
    }
}
