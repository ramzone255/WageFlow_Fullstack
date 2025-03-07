using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Salary_Payment_Payments.Queries.GetSalary_Payment_PaymentsList
{
    public class GetSalary_Payment_PaymentsLookupDto : IMapWith<Domain.src.Entities.Salary_Payment_Payments>
    {
        public int id_salary_payment_payments { get; set; }
        public int? id_payments { get; set; }
        public int? id_salary_payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Salary_Payment_Payments, GetSalary_Payment_PaymentsLookupDto>()
                .ForMember(noteDto => noteDto.id_salary_payment_payments,
                opt => opt.MapFrom(note => note.id_salary_payment_payments))
                .ForMember(noteDto => noteDto.id_payments,
                opt => opt.MapFrom(note => note.id_payments))
                .ForMember(noteDto => noteDto.id_salary_payment,
                opt => opt.MapFrom(note => note.id_salary_payment));
        }
    }
}
