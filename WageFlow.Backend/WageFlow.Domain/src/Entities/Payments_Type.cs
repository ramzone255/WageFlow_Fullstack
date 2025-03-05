using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Payments_Type
    {
        [Key]
        public int id_payments_type {  get; set; }
        public string name_payments_type { get; set; }
        public ICollection<Payments> Payments { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
    }
}
