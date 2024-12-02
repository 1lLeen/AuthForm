using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.UserDto
{
    public class GetUserDto:BaseUserDto, IGet
    {
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}
