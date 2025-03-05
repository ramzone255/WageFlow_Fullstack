using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Work_Entry_Salary_Payment
    {
        [Key]
        public int id_work_entry_salary_payment { get; set; }
        [ForeignKey("Work_Entry")]
        public int? id_work_entry { get; set; }
        public Work_Entry Work_Entry { get; set; }
        [ForeignKey("Salary_Payment")]
        public int? id_salary_payment { get; set; }
        public Salary_Payment Salary_Payment { get; set; }
    }
}
