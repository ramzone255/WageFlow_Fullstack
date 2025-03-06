using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Entry.Queries.GetWork_EntryList
{
    public class GetWork_EntryLookupDto : IMapWith<Domain.src.Entities.Work_Entry>
    {
        public int id_work_entry { get; set; }
        public int quantity_work_entry { get; set; }
        public DateOnly date_work_entry { get; set; }
        public int id_staff { get; set; }
        public int id_work_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Work_Entry, GetWork_EntryLookupDto>()
                .ForMember(noteDto => noteDto.id_work_entry,
                opt => opt.MapFrom(note => note.id_work_entry))
                .ForMember(noteDto => noteDto.quantity_work_entry,
                opt => opt.MapFrom(note => note.quantity_work_entry))
                .ForMember(noteDto => noteDto.date_work_entry,
                opt => opt.MapFrom(note => note.date_work_entry))
                .ForMember(noteDto => noteDto.id_staff,
                opt => opt.MapFrom(note => note.id_staff))
                .ForMember(noteDto => noteDto.id_work_type,
                opt => opt.MapFrom(note => note.id_work_type));
        }
    }
}
