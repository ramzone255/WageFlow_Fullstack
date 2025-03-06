using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostListVm
    {
        public IList<GetPostLookupDto> Post { get; set; }
    }
}
