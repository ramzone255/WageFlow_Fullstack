using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsLookupDto : IMapWith<Domain.src.Entities.Payments>
    {
        public int id_payments { get; set; }
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public DateOnly date_payments { get; set; }
        public int id_staff { get; set; }
        public int id_payments_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Payments, GetPaymentsLookupDto>()
                .ForMember(noteDto => noteDto.id_payments,
                opt => opt.MapFrom(note => note.id_payments))
                .ForMember(noteDto => noteDto.amount_payments,
                opt => opt.MapFrom(note => note.amount_payments))
                .ForMember(noteDto => noteDto.comment,
                opt => opt.MapFrom(note => note.comment))
                .ForMember(noteDto => noteDto.date_payments,
                opt => opt.MapFrom(note => note.date_payments))
                .ForMember(noteDto => noteDto.id_staff,
                opt => opt.MapFrom(note => note.id_staff))
                .ForMember(noteDto => noteDto.id_payments_type,
                opt => opt.MapFrom(note => note.id_payments_type));
        }
    }
}
