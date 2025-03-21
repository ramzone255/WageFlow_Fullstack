using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Frontend.src.Data.Entities.Salary_Payment
{
    public class Salary_Payment
    {
        public int id_salary_payment { get; set; }
        public float amount_salary_payment { get; set; }
        public DateOnly start_date_salary_payment { get; set; }
        public DateOnly end_date_salary_payment { get; set; }
        public DateOnly date_salary_payment { get; set; }
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
    }
}
