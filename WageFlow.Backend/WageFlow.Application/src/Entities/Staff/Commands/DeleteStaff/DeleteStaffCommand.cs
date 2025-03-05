using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Staff.Commands.DeleteStaff
{
    public class DeleteStaffCommand : IRequest
    {
        public int id_staff { get; set; }
    }
}
