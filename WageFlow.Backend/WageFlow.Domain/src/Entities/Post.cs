using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Domain.src.Entities
{
    public class Post
    {
        [Key]
        public int id_post { get; set; }
        public string name_post { get; set; }
        public ICollection<Staff> Staff {  get; set; }
    }
}
