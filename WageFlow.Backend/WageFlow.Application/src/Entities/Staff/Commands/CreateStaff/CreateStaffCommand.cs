using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<int>
    {
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public int id_post { get; set; }
    }
}
