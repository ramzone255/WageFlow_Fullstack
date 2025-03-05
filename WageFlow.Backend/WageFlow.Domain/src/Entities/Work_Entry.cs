using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Work_Entry
    {
        [Key]
        public int id_work_entry {  get; set; }
        public int quantity_work_entry { get; set; }
        public DateOnly date_work_entry { get; set; }
        public ICollection<Work_Entry_Salary_Payment> Work_Entry_Salary_Payment { get; set; }
        public float amount_work_entry => Work_Type != null ? quantity_work_entry * Work_Type.amount_work_type : 0;
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Work_Type")]
        public int id_work_type { get; set; }
        public Work_Type Work_Type { get; set; }
    }
}
