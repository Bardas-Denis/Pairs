using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    public class User
    {
        public User() { }
        public User(String n, String a)
        {
            Name = n;
            Avatar = a;
        }
        public String Name { get; set; }
        public String Avatar { get; set; }

    }
}
