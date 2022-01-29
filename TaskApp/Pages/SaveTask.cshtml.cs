using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;
using TaskApp.Pages.Account;

namespace TaskApp.Pages
{
    [Authorize(Policy = "LoggedUsersOnly")]
    public class SaveTaskModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public SaveTaskModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<tbl_User> tbl_Users { get; set; }
        public async Task OnGet()
        {
            tbl_Users = await _db.tbl_User.ToListAsync();
        }

        [BindProperty]
        public tbl_Taask tbl_Taask { get; set; }

        public async Task<IActionResult> OnPost(IFormFile file)
        {
            byte[] supFile = FileConvert(file);

            if (ModelState.IsValid)
            {
                tbl_Taask.TSK_SUPFILE = supFile;
                await _db.tbl_Taask.AddAsync(tbl_Taask);
                await _db.SaveChangesAsync();

                return RedirectToPage("SaveTask");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }

        public byte[] FileConvert(IFormFile _file)
        {
            byte[] convertedFile = null;

            if (_file != null)
            {
                if (_file.Length > 0)
                {
                    //var fileName = Path.GetFileName(file.FileName);
                    //var fileExtension = Path.GetExtension(fileName);
                    //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var target = new MemoryStream();
                    _file.CopyTo(target);
                    convertedFile = target.ToArray();
                }
            }
            return convertedFile;
        }
    }
}
