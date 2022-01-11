using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskApp.Pages.Account
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public Credantial Credantial { get; set; }
        public void OnGet()
        {
            this.Credantial = new Credantial { UserName = "Admin" };
        }

        public void OnPost()
        {

        }
    }

    public class Credantial
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
