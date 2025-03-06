using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;
using WageFlow.Domain.src.Entities;

namespace WageFlow.Application.src.Entities.Post.Queries.GetPostList
{
    public class GetPostLookupDto : IMapWith<Domain.src.Entities.Post>
    {
        public int id_post { get; set; }
        public string name_post { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Post, GetPostLookupDto>()
                .ForMember(noteDto => noteDto.id_post,
                opt => opt.MapFrom(note => note.id_post))
                .ForMember(noteDto => noteDto.name_post,
                opt => opt.MapFrom(note => note.name_post));
        }
    }
}
