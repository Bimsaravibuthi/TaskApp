using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateUserModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateUserModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<tbl_User> tbl_Users { get; set; }
        public async Task OnGet()
        {
            tbl_Users = await _db.tbl_User.ToListAsync();
        }

        [BindProperty]
        public tbl_User tbl_User { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.tbl_User.AddAsync(tbl_User);
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
