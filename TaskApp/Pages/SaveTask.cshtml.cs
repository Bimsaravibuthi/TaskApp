using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IEnumerable<tbl_User> tbl_Users { get; set; }
        public async Task OnGet()
        {
            tbl_Users = await _db.tbl_User.ToListAsync();
        }

        [BindProperty]
        public tbl_Taask tbl_Taask { get; set; }
        public async Task<IActionResult> OnPost(IFormFile files)
        {
            if (ModelState.IsValid)
            {
                await _db.tbl_Taask.AddAsync(tbl_Taask);
                await _db.SaveChangesAsync();
                return RedirectToPage("SaveTask");
            }
            else
            {
                return RedirectToPage("Error");
            }

            //if(files != null)
            //{
            //    if(files.Length > 0)
            //    {
            //        var fileName = Path.GetFileName(files.FileName);
            //        var fileExtension = Path.GetExtension(fileName);
            //        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            //        var objFiles = new tbl_Taask()
            //        {
            //            TSK_COMID = "KFL",
            //            TSK_ID = "TSK003"
            //        };
            //        using (var target = new MemoryStream())
            //        {
            //            files.CopyTo(target);
            //            objFiles.TSK_SUPFILE = target.ToArray();
            //        }
            //        await _db.tbl_Taask.AddAsync(objFiles);
            //        await _db.SaveChangesAsync();
            //        return RedirectToPage("SaveTask");
            //    }
            //}
            //return RedirectToPage("Error");
        }
    }
}
