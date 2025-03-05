using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;

namespace WageFlow.Application.src.Entities.Staff.Queries.GetStaffList
{
    public class GetStaffLookupDto : IMapWith<Domain.src.Entities.Staff>
    {
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public int id_post { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Staff, GetStaffLookupDto>()
                .ForMember(noteDto => noteDto.id_staff,
                opt => opt.MapFrom(note => note.id_staff))
                .ForMember(noteDto => noteDto.name_staff,
                opt => opt.MapFrom(note => note.name_staff))
                .ForMember(noteDto => noteDto.lastname_staff,
                opt => opt.MapFrom(note => note.lastname_staff))
                .ForMember(noteDto => noteDto.patronymic_staff,
                opt => opt.MapFrom(note => note.patronymic_staff))
                .ForMember(noteDto => noteDto.email_staff,
                opt => opt.MapFrom(note => note.email_staff))
                .ForMember(noteDto => noteDto.id_post,
                opt => opt.MapFrom(note => note.id_post));
        }

    }
}
