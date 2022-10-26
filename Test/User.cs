using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public User()
        {
        }
        public User(string name,string surname,string login,string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }
    }
}
