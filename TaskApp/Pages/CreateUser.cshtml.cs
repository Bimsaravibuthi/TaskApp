using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateUserModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> Users { get; set; }
        public async Task OnGet()
        {
            Users = await _db.User.ToListAsync();
        }

        [BindProperty]
        public User User { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.User.AddAsync(User);
                await _db.SaveChangesAsync();
                return RedirectToPage("CreateUser");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }
    }
}
