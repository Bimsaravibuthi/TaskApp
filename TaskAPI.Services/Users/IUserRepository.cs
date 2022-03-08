using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Users
{
    public interface IUserRepository
    {
        public List<Uuser> GetAllUsers();
        public List<Uuser> FilterAndSearchUsers(string userLevel);
        public Uuser GetUser(string id);
    }
}
