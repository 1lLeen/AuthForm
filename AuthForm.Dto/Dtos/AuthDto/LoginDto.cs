﻿using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.AuthDto
{
    public class LoginDto:IBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
