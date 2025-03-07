using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Work_Entry_Salary_Payment.Queries.GetWork_Entry_Salary_PaymentList
{
    public class GetWork_Entry_Salary_PaymentLookupDto : IMapWith<Domain.src.Entities.Work_Entry_Salary_Payment>
    {
        public int id_work_entry_salary_payment { get; set; }
        public int? id_work_entry { get; set; }
        public int? id_salary_payment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Work_Entry_Salary_Payment, GetWork_Entry_Salary_PaymentLookupDto>()
                .ForMember(noteDto => noteDto.id_work_entry_salary_payment,
                opt => opt.MapFrom(note => note.id_work_entry_salary_payment))
                .ForMember(noteDto => noteDto.id_work_entry,
                opt => opt.MapFrom(note => note.id_work_entry))
                .ForMember(noteDto => noteDto.id_salary_payment,
                opt => opt.MapFrom(note => note.id_salary_payment));
        }
    }
}
