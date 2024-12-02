using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.AuthDto
{
    public class AuthGetDto:IBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
