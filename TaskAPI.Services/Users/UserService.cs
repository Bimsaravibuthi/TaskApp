using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Users
{
    public class UserService : IUserRepository
    {      
        public List<Uuser> GetAllUsers()
        {
            var users = new List<Uuser>();

            var user1 = new Uuser
            {
                USR_ID = "KFL001",
                USR_PASSWORD = "aV0u0skVyx+LmiPz8FBXCA==",
                USR_NIC = "880112934V",
                USR_NAMEFULL = "Nalin Manoj",
                USR_LEVEL = "1"
            };
            users.Add(user1);

            return users;
        }
    }
}
