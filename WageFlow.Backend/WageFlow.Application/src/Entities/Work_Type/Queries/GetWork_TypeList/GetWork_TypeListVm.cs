using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList
{
    public class GetWork_TypeListVm
    {
        public IList<GetWork_TypeLookupDto> Work_Type { get; set; }
    }
}
