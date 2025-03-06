using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.EntitiesDto.PaymentsDto
{
    public class CreatePaymentsDto : IMapWith<CreatePaymentsCommand>
    {
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public DateOnly date_payments { get; set; }
        public int id_staff { get; set; }
        public int id_payments_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePaymentsDto, CreatePaymentsCommand>()
                .ForMember(entityDto => entityDto.amount_payments,
                opt => opt.MapFrom(entity => entity.amount_payments))
                .ForMember(entityDto => entityDto.comment,
                opt => opt.MapFrom(entity => entity.comment))
                .ForMember(entityDto => entityDto.date_payments,
                opt => opt.MapFrom(entity => entity.date_payments))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff))
                .ForMember(entityDto => entityDto.id_payments_type,
                opt => opt.MapFrom(entity => entity.id_payments_type));
        }
    }
}
