using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Model;


namespace MyApp.Repository
{
    public class UserRepository
    {
        // Deklarasi variabel dengan nilai default
        private User[] users = new User[]
        {
            new User { Id = 1, Username = "admin", Password = "admin" },
            new User { Id = 2, Username = "user", Password = "user" }
        };

        // Method untuk memvalidasi user dan password
        public bool ValidateUser(User user)
        {
            foreach (User u in users)
            {
                if (u.Username == user.Username && u.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}