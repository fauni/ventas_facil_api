﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Login
{
    public class LoginRequestModel
    {
        public string CompanyDB { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Language { get; set; }
    }
}
