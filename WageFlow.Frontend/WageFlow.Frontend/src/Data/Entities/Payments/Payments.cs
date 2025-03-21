using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Frontend.src.Data.Entities.Payments
{
    public class Payments
    {
        public int id_payments { get; set; }
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public DateOnly date_payments { get; set; }
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public int id_payments_type { get; set; }
        public string name_payments_type { get; set; }
    }
}
