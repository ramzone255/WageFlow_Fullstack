using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.EntitiesDto.Work_EntryDto
{
    public class CreateWork_EntryDto : IMapWith<CreateWork_EntryCommand>
    {
        public int quantity_work_entry { get; set; }
        public int id_staff { get; set; }
        public int id_work_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWork_EntryDto, CreateWork_EntryCommand>()
                .ForMember(entityDto => entityDto.quantity_work_entry,
                opt => opt.MapFrom(entity => entity.quantity_work_entry))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff))
                .ForMember(entityDto => entityDto.id_work_type,
                opt => opt.MapFrom(entity => entity.id_work_type));
        }
    }
}
