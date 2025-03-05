using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Staff
    {
        [Key]
        public int id_staff { get; set; }
        public string lastname_staff { get; set; }
        public string name_staff { get; set; }
        public string patronymic_staff { get; set; }
        public string email_staff { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<Work_Entry> Work_Entry { get; set; }
        [ForeignKey("Post")]
        public int id_post { get; set; }
        public Post Post { get; set; }
    }
}
