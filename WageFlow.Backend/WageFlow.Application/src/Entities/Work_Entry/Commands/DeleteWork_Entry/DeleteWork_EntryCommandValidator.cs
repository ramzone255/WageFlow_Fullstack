using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.DeleteWork_Entry
{
    public class DeleteWork_EntryCommandValidator
        : AbstractValidator<DeleteWork_EntryCommand>
    {
        public DeleteWork_EntryCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_work_entry).NotEmpty();
        }
    }
}
