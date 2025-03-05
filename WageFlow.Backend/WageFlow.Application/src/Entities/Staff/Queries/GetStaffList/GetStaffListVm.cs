using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Queries.GetStaffList
{
    public class GetStaffListVm
    {
        public IList<GetStaffLookupDto> Staff { get; set; }
    }
}
