using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Salary_Payment
    {
        [Key]
        public int id_salary_payment {  get; set; }
        public float amount_salary_payment { get; set; }
        public DateOnly date_salary_payment { get; set; }
        public ICollection<Work_Entry_Salary_Payment> Work_Entry_Salary_Payment { get; set; }
        public ICollection<Salary_Payment_Payments> Salary_Payment_Payments { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
    }
}
