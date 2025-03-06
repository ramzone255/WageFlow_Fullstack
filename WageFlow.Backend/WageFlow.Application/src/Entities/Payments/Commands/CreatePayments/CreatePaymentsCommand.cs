using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommand : IRequest<int>
    {
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public DateOnly date_payments { get; set; }
        public int id_staff { get; set; }
        public int id_payments_type { get; set; }
    }
}
