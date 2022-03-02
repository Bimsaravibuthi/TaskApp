using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPIDataAccess
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Taask> Taasks { get; set; }
        public DbSet<Uuser> Uusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=MyToDoDb;Trusted_Connection=True;MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author {Id = 1, FullName = "Bimsara Vibuthi"},
                new Author {Id = 2, FullName = "Chamara Madhusanka"},
                new Author {Id = 3, FullName = "Dinesh Indunil"},
                new Author {Id = 4, FullName = "Ravidu Hasmitha"}
            });

            modelBuilder.Entity<Todo>().HasData(new Todo[]
            {
                new Todo
                {
                    Id = 1,
                    Title = "Get books for school - DB",
                    Description = "Get some text books for school",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(5),
                    Status = TodoStatus.New,
                    AuthorId = 1
                },
                new Todo
                {
                    Id = 2,
                    Title = "Get vegitables - DB",
                    Description = "Get vegitables for the week",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(2),
                    Status = TodoStatus.New,
                    AuthorId = 1
                },
                new Todo
                {
                    Id = 3,
                    Title = "Water the plants",
                    Description = "Water the all plants quickly",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(1),
                    Status = TodoStatus.New,
                    AuthorId = 2
                }
            });
        }
    }
}
