using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Dto.Dtos.UserDto
{
    public class UpdateUserDto:BaseUserDto, IUpdate
    {
        public DateTime UpdatedTime { get; set; }= DateTime.Now;
    }
}
