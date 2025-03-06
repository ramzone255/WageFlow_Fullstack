﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommand : IRequest
    {
        public int id_payments { get; set; }
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public int id_staff { get; set; }
        public int id_payments_type { get; set; }
    }
}
