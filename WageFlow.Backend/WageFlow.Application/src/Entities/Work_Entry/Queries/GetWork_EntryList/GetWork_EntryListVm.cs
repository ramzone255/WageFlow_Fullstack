using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList
{
    public class GetWork_EntryListVm
    {
        public IList<GetWork_EntryLookupDto> Work_Entry { get; set; }
    }
}
