using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry
{
    public class UpdateWork_EntryCommandValidator
        : AbstractValidator<UpdateWork_EntryCommand>
    {
        public UpdateWork_EntryCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_work_entry).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quantity_work_entry).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_staff).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_work_type).NotEmpty();
        }
    }
}
