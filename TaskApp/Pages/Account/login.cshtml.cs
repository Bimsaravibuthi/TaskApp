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

namespace TaskApp.Pages.Account
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public Credantial Credantial { get; set; }
        [BindProperty]
        public Cooki Cooki { get; set; }

        public void OnGet()
        {
            //this.Credantial = new Credantial { UserName = "Admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid) return Page();

            if (Credantial.UserName == "admin" && Credantial.Password == "password")
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

    public class Cooki
    {
        public string Coo_ID { get; set; }
    }
}
