using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;
using TaskApp.Pages.Account;

namespace TaskApp.Pages
{
    public class SaveTaskModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SaveTaskModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Credantial> Credantials { get; set; }
        public async Task OnGet()
        {
            Users = await _db.User.ToListAsync();
            Credantials = Credantials.ToList();
        }

        [BindProperty]
        public Taask Taask { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Taask.AddAsync(Taask);
                await _db.SaveChangesAsync();
                return RedirectToPage("SaveTask");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }
    }
}
