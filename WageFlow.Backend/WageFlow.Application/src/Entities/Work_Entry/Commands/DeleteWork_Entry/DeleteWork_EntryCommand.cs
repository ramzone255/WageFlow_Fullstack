using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.Work_Entry.Commands.DeleteWork_Entry
{
    public class DeleteWork_EntryCommand : IRequest
    {
        public int id_work_entry { get; set; }
    }
}
