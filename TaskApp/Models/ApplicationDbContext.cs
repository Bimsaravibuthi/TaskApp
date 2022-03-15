using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Uuser> Uuser { get; set; }
        public DbSet<Taask> Taask { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Max_Task_ID> Max_Task_ID { get; set; }

    }
}
