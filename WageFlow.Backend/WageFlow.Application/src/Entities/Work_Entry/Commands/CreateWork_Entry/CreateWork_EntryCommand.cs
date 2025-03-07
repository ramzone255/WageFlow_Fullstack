using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.CreateWork_Entry
{
    public class CreateWork_EntryCommand : IRequest<int>
    {
        public int quantity_work_entry { get; set; }
        public int id_staff { get; set; }
        public int id_work_type { get; set; }
    }
}
