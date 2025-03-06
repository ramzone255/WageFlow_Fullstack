using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommandValidator
        : AbstractValidator<CreatePaymentsCommand>
    {
        public CreatePaymentsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.amount_payments).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.comment).MaximumLength(50).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.date_payments).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_staff).NotEmpty();
            RuleFor(createEntityCommand =>
            createEntityCommand.id_payments_type).NotEmpty();
        }
    }
}
