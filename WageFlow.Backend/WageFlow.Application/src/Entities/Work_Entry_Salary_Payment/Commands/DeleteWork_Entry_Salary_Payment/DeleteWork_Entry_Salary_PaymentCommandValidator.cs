using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.DeleteWork_Entry_Salary_Payment
{
    public class DeleteWork_Entry_Salary_PaymentCommandValidator
        : AbstractValidator<DeleteWork_Entry_Salary_PaymentCommand>
    {
        public DeleteWork_Entry_Salary_PaymentCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_work_entry_salary_payment).NotEmpty();
        }
    }
}
