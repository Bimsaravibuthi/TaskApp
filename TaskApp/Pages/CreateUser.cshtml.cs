using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;
using TaskApp.Security;

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

        public IEnumerable<Tbl_User> Tbl_User_OnGet { get; set; }
        public async Task OnGet()
        {
            Tbl_User_OnGet = await _db.Tbl_User.ToListAsync();
        }

        [BindProperty]
        public Tbl_User Tbl_User { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Tbl_User.USR_PASSWORD = PWD_EN_DE.EncryptString(Tbl_User.USR_PASSWORD.ToString());
                Tbl_User.USR_CREATEDATE = DateTime.Now;
                await _db.Tbl_User.AddAsync(Tbl_User);
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
