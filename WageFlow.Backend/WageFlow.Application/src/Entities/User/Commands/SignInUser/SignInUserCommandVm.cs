using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Application.src.Entities.User.Commands.SignInUser
{
    public class SignInUserCommandVm
    {
        public int id_post { get; set; }
        public int id_staff { get; set; }
        public string name_post { get; set; }
        public SignInUserCommandVm(int Id_post, int Id_staff, string Name_post)
        {
            id_post = Id_post;
            id_staff = Id_staff;
            name_post = Name_post;
        }
    }
}
