using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartoteka
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }
        public static ObservableCollection<User> UserList = new ObservableCollection<User>();
    }
}
