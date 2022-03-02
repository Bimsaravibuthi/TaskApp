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
        public List<Taask> GetAllTaasks()
        {
            return _context.Taasks.ToList();
        }
    }
}
