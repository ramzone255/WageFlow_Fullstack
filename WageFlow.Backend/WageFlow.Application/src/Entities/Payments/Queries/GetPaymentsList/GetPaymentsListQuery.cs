using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListQuery : IRequest<GetPaymentsListVm>
    {
        public int id_payments { get; set; }
    }
}
