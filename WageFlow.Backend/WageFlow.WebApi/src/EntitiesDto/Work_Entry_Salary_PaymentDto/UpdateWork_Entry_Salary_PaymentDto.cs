using AutoMapper;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.UpdateWork_Entry_Salary_Payment;

namespace WageFlow.WebApi.src.EntitiesDto.Work_Entry_Salary_PaymentDto
{
    public class UpdateWork_Entry_Salary_PaymentDto : IMapWith<UpdateWork_Entry_Salary_PaymentCommand>
    {
        public int? id_work_entry { get; set; }
        public int? id_salary_payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateWork_Entry_Salary_PaymentDto, UpdateWork_Entry_Salary_PaymentCommand>()
                .ForMember(entityDto => entityDto.id_work_entry,
                opt => opt.MapFrom(entity => entity.id_work_entry))
                .ForMember(entityDto => entityDto.id_salary_payment,
                opt => opt.MapFrom(entity => entity.id_salary_payment));
        }
    }
}
