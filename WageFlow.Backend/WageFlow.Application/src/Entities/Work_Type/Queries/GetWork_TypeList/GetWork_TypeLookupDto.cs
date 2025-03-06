using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Type.Queries.GetWork_TypeList
{
    public class GetWork_TypeLookupDto : IMapWith<Domain.src.Entities.Work_Type>
    {
        public int id_work_type { get; set; }
        public string name_work_type { get; set; }
        public float amount_work_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Work_Type, GetWork_TypeLookupDto>()
                .ForMember(noteDto => noteDto.id_work_type,
                opt => opt.MapFrom(note => note.id_work_type))
                .ForMember(noteDto => noteDto.name_work_type,
                opt => opt.MapFrom(note => note.name_work_type))
                .ForMember(noteDto => noteDto.amount_work_type,
                opt => opt.MapFrom(note => note.amount_work_type));
        }
    }
}
