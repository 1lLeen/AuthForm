using AuthForm.Dto.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.Services.Interfaces
{
    public interface IUserService : IAbstractService<GetUserDto, CreateUserDto, UpdateUserDto>
    {
        Task<GetUserDto?> GetByEmail(string email);
        Task<GetUserDto?> GetByEmailAndPassword(string email, string password);
        Task<GetUserDto> RegisterNewUser(string email,string login, string password);
        Task GenerateNewEmailCodeForUser(string email);
        Task GenerateNewResetPasswordCodeForUser(string email);
        Task<GetUserDto?> TryToConfirmEmail(string email, string emailCode);
        Task SendConfirmEmail(string email);
        Task SendResetCodeEmail(string email);
        Task<GetUserDto?> ResetPassword(string email, string emailCode, string newPassword);
    }
}
