using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Salary_Payment_Payments.Commands.CreateSalary_Payment_Payments;
using WageFlow.Application.src.Entities.Staff.Commands.CreateStaff;
using WageFlow.Domain.src.Entities;
using WageFlow.WebApi.src.EntitiesDto.StaffDto;

namespace WageFlow.WebApi.src.EntitiesDto.Salary_Payment_PaymentsDto
{
    public class CreateSalary_Payment_PaymentsDto
        : IMapWith<CreateSalary_Payment_PaymentsCommand>
    {
        public int? id_payments { get; set; }
        public int? id_salary_payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSalary_Payment_PaymentsDto, CreateSalary_Payment_PaymentsCommand>()
                .ForMember(entityDto => entityDto.id_payments,
                opt => opt.MapFrom(entity => entity.id_payments))
                .ForMember(entityDto => entityDto.id_salary_payment,
                opt => opt.MapFrom(entity => entity.id_salary_payment));
        }
    }
}
