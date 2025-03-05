using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Queries.GetStaffList
{
    public class GetStaffListQuery : IRequest<GetStaffListVm>
    {
        public int id_staff { get; set; }
    }
}
