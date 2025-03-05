using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Salary_Payment_Payments
    {
        [Key]
        public int id_salary_payment_payments { get; set; }
        [ForeignKey("Payments")]
        public int? id_payments { get; set; }
        public Payments Payments { get; set; }
        [ForeignKey("Salary_Payment")]
        public int? id_salary_payment { get; set; }
        public Salary_Payment Salary_Payment { get; set; }
    }
}
