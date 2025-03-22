using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Frontend.src.Data.Entities.Work_Entry
{
    public class Work_Entry
    {
        public int id_work_entry { get; set; }
        public int quantity_work_entry { get; set; }
        public DateOnly date_work_entry { get; set; }
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public int id_work_type { get; set; }
        public string name_work_type { get; set; }
        public float amount_work_type { get; set; }
    }
}
