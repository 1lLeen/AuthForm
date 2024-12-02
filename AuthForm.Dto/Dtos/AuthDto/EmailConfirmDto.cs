using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.AuthDto
{
    public class EmailConfirmDto:IBase
    {
        public string Email { get; set; }
        public string EmailCode { get; set; }
    }
}
