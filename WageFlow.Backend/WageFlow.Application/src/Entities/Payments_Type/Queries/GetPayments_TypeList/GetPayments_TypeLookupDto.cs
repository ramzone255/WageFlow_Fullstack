using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Application.src.Entities.Staff.Queries.GetStaffList;

namespace WageFlow.Application.src.Entities.Payments_Type.Queries.GetPayments_TypeList
{
    public class GetPayments_TypeLookupDto : IMapWith<Domain.src.Entities.Payments_Type>
    {
        public int id_payments_type { get; set; }
        public string name_payments_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Payments_Type, GetPayments_TypeLookupDto>()
                .ForMember(noteDto => noteDto.id_payments_type,
                opt => opt.MapFrom(note => note.id_payments_type))
                .ForMember(noteDto => noteDto.name_payments_type,
                opt => opt.MapFrom(note => note.name_payments_type));
        }
    }
}
