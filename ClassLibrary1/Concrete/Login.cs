﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
    }
}
