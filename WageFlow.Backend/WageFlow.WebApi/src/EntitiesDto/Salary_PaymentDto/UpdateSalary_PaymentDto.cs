using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.CreateSalary_Payment;
using WageFlow.Application.src.Entities.Salary_Payment.Commands.UpdateSalary_Payment;

namespace WageFlow.WebApi.src.EntitiesDto.Salary_PaymentDto
{
    public class UpdateSalary_PaymentDto : IMapWith<UpdateSalary_PaymentCommand>
    {
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public int id_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSalary_PaymentDto, UpdateSalary_PaymentCommand>()
                .ForMember(entityDto => entityDto.start_date_salary_payment,
                opt => opt.MapFrom(entity => entity.start_date_salary_payment))
                .ForMember(entityDto => entityDto.end_date_salary_payment,
                opt => opt.MapFrom(entity => entity.end_date_salary_payment))
                .ForMember(entityDto => entityDto.id_staff,
                opt => opt.MapFrom(entity => entity.id_staff));
        }
    }
}
