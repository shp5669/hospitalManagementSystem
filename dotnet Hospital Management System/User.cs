using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Hospital_Management_System
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string password)
        {
            ID = id;
            Name = name;
            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }

}
