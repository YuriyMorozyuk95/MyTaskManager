using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibarary.BackEnd.SQLEntityConnection
{
    public class Authorization
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return login;
        }

    }
}
