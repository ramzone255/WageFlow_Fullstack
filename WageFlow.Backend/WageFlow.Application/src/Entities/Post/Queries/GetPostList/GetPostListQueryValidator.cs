using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostListQueryValidator
        : AbstractValidator<GetPostListQuery>
    {
        public GetPostListQueryValidator()
        {
            RuleFor(entity => entity.id_post);
        }
    }
}
