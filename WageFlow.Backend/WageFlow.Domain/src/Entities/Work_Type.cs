using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Work_Type
    {
        [Key]
        public int id_work_type {  get; set; }
        public string name_work_type { get; set; }
        public float amount_work_type { get; set; }
        public ICollection<Work_Entry> Work_Entry { get; set; }
    }
}
