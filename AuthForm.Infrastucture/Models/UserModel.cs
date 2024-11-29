using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture.Models
{
    public class UserModel:BaseModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string EmailCode { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}
