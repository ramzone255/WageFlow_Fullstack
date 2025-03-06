using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList
{
    public class GetWork_TypeListQuery : IRequest<GetWork_TypeListVm>
    {
        public int id_work_type { get; set; }
    }
}
