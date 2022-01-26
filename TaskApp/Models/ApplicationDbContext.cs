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
        public DbSet<tbl_User> tbl_User { get; set; }
        public DbSet<tbl_Taask> tbl_Taask { get; set; }
        public DbSet<login> login { get; set; }

    }
}
