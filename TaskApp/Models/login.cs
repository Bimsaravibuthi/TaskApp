using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{
    public class login
    {
        [Key]
        public string USR_ID { get; set; }
        public string USR_PASSWORD { get; set; }
    }
}
