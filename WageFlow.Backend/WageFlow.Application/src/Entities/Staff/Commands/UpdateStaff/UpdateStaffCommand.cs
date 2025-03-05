using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommand : IRequest
    {
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public int id_post { get; set; }
    }
}
