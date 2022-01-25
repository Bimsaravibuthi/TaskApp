using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Pages.Account
{
    public class loginModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public loginModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Credantial Credantial { get; set; }

        public void OnGet()
        {
            //this.Credantial = new Credantial { UserName = "Admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid) return Page();

            //if (Credantial.UserName == "admin" && Credantial.Password == "password")
            if(userValidate(Credantial.UserName, Credantial.Password))
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("User_ID", "KFL001"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", ""),
                    new Claim("Manager", "")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }

        public bool userValidate(string _emai, string _passwd)
        {
            //var result = _db.login.FromSql($ "SELECT * FROM dbo.Usr_Login");

            return true;
        }
    }

    public class Credantial
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
