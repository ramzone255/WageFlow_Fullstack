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
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public DateOnly date_salary_payment { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
    }
}
