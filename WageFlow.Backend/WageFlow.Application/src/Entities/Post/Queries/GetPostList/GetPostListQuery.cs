using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostListQuery : IRequest<GetPostListVm>
    {
        public int id_post { get; set; }
    }
}
