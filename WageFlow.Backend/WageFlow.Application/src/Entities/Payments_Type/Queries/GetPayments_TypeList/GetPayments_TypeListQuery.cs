using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList
{
    public class GetPayments_TypeListQuery : IRequest<GetPayments_TypeListVm>
    {
        public int id_payments_type { get; set; }
    }
}
