using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;
using TaskAPIDataAccess;

namespace TaskAPI.Services.Users
{
    public class UserSqlServerService : IUserRepository
    {
        private readonly TodoDbContext _context = new TodoDbContext();
        public List<Uuser> GetAllUsers()
        {
            return _context.Uusers.ToList();
        }

        public List<Uuser> FilterAndSearchUsers(string userLevel)
        {
            if(string.IsNullOrWhiteSpace(userLevel))
            {
                return GetAllUsers();
            }

            userLevel = userLevel.Trim();

            return _context.Uusers.Where(t => t.USR_LEVEL == userLevel).ToList();
        }

        public Uuser GetUser(string id)
        {
            return _context.Uusers.Find(id);
        }
    }
}
