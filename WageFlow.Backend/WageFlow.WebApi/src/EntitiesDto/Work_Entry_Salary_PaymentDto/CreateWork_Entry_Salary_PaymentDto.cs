using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Commands.CreateWork_Entry_Salary_Payment;
using WageFlow.Domain.src.Entities;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.EntitiesDto.Work_Entry_Salary_PaymentDto
{
    public class CreateWork_Entry_Salary_PaymentDto : IMapWith<CreateWork_Entry_Salary_PaymentCommand>
    {
        public int? id_work_entry { get; set; }
        public int? id_salary_payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateWork_Entry_Salary_PaymentDto, CreateWork_Entry_Salary_PaymentCommand>()
                .ForMember(entityDto => entityDto.id_work_entry,
                opt => opt.MapFrom(entity => entity.id_work_entry))
                .ForMember(entityDto => entityDto.id_salary_payment,
                opt => opt.MapFrom(entity => entity.id_salary_payment));
        }
    }
}
