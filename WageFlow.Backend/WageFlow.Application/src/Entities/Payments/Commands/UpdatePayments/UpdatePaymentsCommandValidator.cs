using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommandValidator
        : AbstractValidator<UpdatePaymentsCommand>
    {
        public UpdatePaymentsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_payments).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.amount_payments).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.comment).MaximumLength(50).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_staff).NotEmpty();
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_payments_type).NotEmpty();
        }
    }
}
