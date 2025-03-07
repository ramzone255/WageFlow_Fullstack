using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.UpdateWork_Entry_Salary_Payment
{
    public class UpdateWork_Entry_Salary_PaymentCommandValidator
        : AbstractValidator<UpdateWork_Entry_Salary_PaymentCommand>
    {
        public UpdateWork_Entry_Salary_PaymentCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_work_entry_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_salary_payment).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_work_entry).NotEmpty();
        }
    }
}
