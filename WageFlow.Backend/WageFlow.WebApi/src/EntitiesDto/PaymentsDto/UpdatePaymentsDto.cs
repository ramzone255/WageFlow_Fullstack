using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Payments.Commands.CreatePayments;
using WageFlow.Application.src.Entities.Payments.Commands.UpdatePayments;

namespace WageFlow.WebApi.src.EntitiesDto.PaymentsDto
{
    public class UpdatePaymentsDto : IMapWith<UpdatePaymentsCommand>
    {
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public int id_staff { get; set; }
        public int id_payments_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePaymentsDto, UpdatePaymentsCommand>()
                .ForMember(entityDto => entityDto.amount_payments,
                opt => opt.MapFrom(entity => entity.amount_payments))
                .ForMember(entityDto => entityDto.comment,
                opt => opt.MapFrom(entity => entity.comment))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff))
                .ForMember(entityDto => entityDto.id_payments_type,
                opt => opt.MapFrom(entity => entity.id_payments_type));
        }
    }
}
