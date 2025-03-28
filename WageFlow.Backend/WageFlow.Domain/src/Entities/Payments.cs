﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Payments
    {
        [Key]
        public int id_payments { get; set; }
        public float amount_payments { get; set; }
        public string comment { get; set; }
        public DateOnly date_payments { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Payments_Type")]
        public int id_payments_type { get; set; }
        public Payments_Type Payments_Type { get; set; }
    }
}
