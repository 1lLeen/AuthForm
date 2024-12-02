using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.AuthDto
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string EmailCode { get; set; }
        public string NewPassword { get; set; }
    }
}
