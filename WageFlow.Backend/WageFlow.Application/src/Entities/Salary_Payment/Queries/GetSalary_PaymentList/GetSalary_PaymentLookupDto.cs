using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Salary_Payment.Queries.GetSalary_PaymentList
{
    public class GetSalary_PaymentLookupDto : IMapWith<Domain.src.Entities.Salary_Payment>
    {
        public int id_salary_payment { get; set; }
        public float amount_salary_payment { get; set; }
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public DateOnly date_salary_payment { get; set; }
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Salary_Payment, GetSalary_PaymentLookupDto>()
                .ForMember(noteDto => noteDto.id_salary_payment,
                opt => opt.MapFrom(note => note.id_salary_payment))
                .ForMember(noteDto => noteDto.amount_salary_payment,
                opt => opt.MapFrom(note => note.amount_salary_payment))
                .ForMember(noteDto => noteDto.start_date_salary_payment,
                opt => opt.MapFrom(note => note.start_date_salary_payment))
                .ForMember(noteDto => noteDto.end_date_salary_payment,
                opt => opt.MapFrom(note => note.end_date_salary_payment))
                .ForMember(noteDto => noteDto.date_salary_payment,
                opt => opt.MapFrom(note => note.date_salary_payment))
                .ForMember(noteDto => noteDto.id_staff,
                opt => opt.MapFrom(note => note.id_staff))
                .ForMember(noteDto => noteDto.lastname_staff,
                opt => opt.MapFrom(note => note.Staff.lastname_staff))
                .ForMember(noteDto => noteDto.name_staff,
                opt => opt.MapFrom(note => note.Staff.name_staff))
                .ForMember(noteDto => noteDto.patronymic_staff,
                opt => opt.MapFrom(note => note.Staff.patronymic_staff));
        }
    }
}
