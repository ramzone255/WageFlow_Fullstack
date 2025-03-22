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
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public int id_work_type { get; set; }
        public string name_work_type { get; set; }
        public float amount_work_type { get; set; }

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
                .ForMember(noteDto => noteDto.lastname_staff,
                opt => opt.MapFrom(note => note.Staff.lastname_staff))
                .ForMember(noteDto => noteDto.name_staff,
                opt => opt.MapFrom(note => note.Staff.name_staff))
                .ForMember(noteDto => noteDto.patronymic_staff,
                opt => opt.MapFrom(note => note.Staff.patronymic_staff))
                .ForMember(noteDto => noteDto.id_work_type,
                opt => opt.MapFrom(note => note.id_work_type))
                .ForMember(noteDto => noteDto.name_work_type,
                opt => opt.MapFrom(note => note.Work_Type.name_work_type))
                .ForMember(noteDto => noteDto.amount_work_type,
                opt => opt.MapFrom(note => note.Work_Type.amount_work_type));
        }
    }
}
