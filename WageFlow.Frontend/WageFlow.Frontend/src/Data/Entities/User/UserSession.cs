using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WageFlow.Frontend.src.Data.Entities.User
{
    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}
