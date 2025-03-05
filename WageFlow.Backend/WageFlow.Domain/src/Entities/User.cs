using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        [ForeignKey("Staff")]
        public int id_staff { get; set; }
        public Staff Staff { get; set; }
    }
}
