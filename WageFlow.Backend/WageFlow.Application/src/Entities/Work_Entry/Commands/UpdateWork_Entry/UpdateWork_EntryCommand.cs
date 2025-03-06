using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.UpdateWork_Entry
{
    public class UpdateWork_EntryCommand : IRequest
    {
        public int id_work_entry { get; set; }
        public int quantity_work_entry { get; set; }
        public int id_staff { get; set; }
        public int id_work_type { get; set; }
    }
}
