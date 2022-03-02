using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAPI.Models
{
    public class Uuser
    {
        [Key]
        public string USR_ID { get; set; }
        public string USR_PASSWORD { get; set; }
        public string USR_NIC { get; set; }
        public string USR_NAMEFULL { get; set; }
        public DateTime USR_CREATEDATE { get; set; }
        public string USR_LEVEL { get; set; }
    }
}
