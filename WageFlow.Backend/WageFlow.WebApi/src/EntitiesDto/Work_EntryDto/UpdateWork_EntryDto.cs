using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry;
using WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry;

namespace WageFlow.WebApi.src.EntitiesDto.Work_EntryDto
{
    public class UpdateWork_EntryDto : IMapWith<UpdateWork_EntryCommand>
    {
        public int quantity_work_entry { get; set; }
        public int id_staff { get; set; }
        public int id_work_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWork_EntryDto, UpdateWork_EntryCommand>()
                .ForMember(entityDto => entityDto.quantity_work_entry,
                opt => opt.MapFrom(entity => entity.quantity_work_entry))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff))
                .ForMember(entityDto => entityDto.id_work_type,
                opt => opt.MapFrom(entity => entity.id_work_type));
        }
    }
}
