using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;
using TaskAPIDataAccess;

namespace TaskAPI.Services.Taasks
{
    public class TaaskSqlServerService : ITaasksRepository
    {
        private readonly TodoDbContext _context = new TodoDbContext();
        public List<Taask> GetAllTasks(string userId)
        {
            return _context.Taasks.Where(t => t.TSK_CREATEUSER == userId).ToList();
        }

        public Taask GetTask(string userId, string id)
        {
            return _context.Taasks.FirstOrDefault(t => t.TSK_ID == id && t.TSK_CREATEUSER == userId);
        }
    }
}
