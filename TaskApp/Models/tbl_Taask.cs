﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{
    public class Tbl_Taask
    {
        [Key]
        public string TSK_ID { get; set; }
        public string TSK_COMID { get; set; }     
        public DateTime TSK_STDATE { get; set; }
        public DateTime TSK_ENDATE { get; set; }
        public string TSK_ASSUSER { get; set; }
        public string TSK_DESC { get; set; }
        public byte[] TSK_SUPFILE { get; set; }
        public int TSK_PRIORITY { get; set; }
        public string TSK_CREATEUSER { get; set; }
    }
}
