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

        public IEnumerable<Tbl_User> Tbl_Users { get; set; }
        public IEnumerable<Max_Task_ID> Max_Task_ID { get; set; }
        public async Task OnGet()
        {
            var maxTaskId = GetMaxTaskId();

            Tbl_Users = await _db.Tbl_User.ToListAsync();
            Max_Task_ID = maxTaskId;

        }

        [BindProperty]
        public Tbl_Taask Tbl_Taask { get; set; }

        public async Task<IActionResult> OnPost(List<IFormFile> file)
        {
            int TaskId = 0;

            var maxTaskId = GetMaxTaskId();
            //byte[] supFile = FileConvert(file);

            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        Tbl_Taask.TSK_SUPFILE = stream.ToArray();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                foreach (var item in maxTaskId)
                {
                    TaskId = Int32.Parse(item.TSK_ID);
                }
                TaskId++;
                Tbl_Taask.TSK_ID = TaskId.ToString();
                await _db.Tbl_Taask.AddAsync(Tbl_Taask);
                await _db.SaveChangesAsync();

                return RedirectToPage("SaveTask");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }

        public IEnumerable<Max_Task_ID> GetMaxTaskId()
        {
            Max_Task_ID = _db.Max_Task_ID.FromSqlRaw("[dbo].[Select_Max_Tsk_Id]");
            return Max_Task_ID;
        }
        public byte[] FileConvert(List<IFormFile> _file)
        {
            byte[] convertedFile = null;

            foreach (var item in _file)
            {
                if(item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        
                    }
                }
            }

            //if (_file != null)
            //{
            //    if (_file.Length > 0)
            //    {
            //        //var fileName = Path.GetFileName(file.FileName);
            //        //var fileExtension = Path.GetExtension(fileName);
            //        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

            //        var target = new MemoryStream();
            //        _file.CopyTo(target);
            //        convertedFile = target.ToArray();
            //    }
            //}
            return convertedFile;
        }
    }
}
