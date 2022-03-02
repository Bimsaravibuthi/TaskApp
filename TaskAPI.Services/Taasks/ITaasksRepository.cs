using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Taasks
{
    public interface ITaasksRepository
    {
        public List<Taask> GetAllTaasks();
    }
}
