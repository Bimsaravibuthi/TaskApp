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
        string glob_UserLevel;

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
                string adminPermission = "";
                if(glob_UserLevel.Equals("1"))
                {
                    adminPermission = "True";
                }

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("User_ID", Credantial.UserName),
                    new Claim("Department", "HR"),
                    new Claim("Admin", adminPermission),
                    new Claim("Manager", "True")
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
            try
            {
                var result = _db.login.FromSqlRaw("[dbo].[Usr_Login]{0}", _emai).ToList();
                if (result[0].USR_ID != "")
                {
                    if (_passwd == result[0].USR_PASSWORD.ToString())
                    {
                        glob_UserLevel = result[0].USR_LEVEL.ToString();
                        return true;
                    }                   
                }
                else
                {
                    return false;
                }              
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
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
