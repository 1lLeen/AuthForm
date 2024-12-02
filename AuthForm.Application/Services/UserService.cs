using AuthForm.Application.EmailHelper;
using AuthForm.Application.Services.Interfaces;
using AuthForm.Dto.Dtos.UserDto;
using AuthForm.Infrastucture.Models;
using AuthForm.Infrastucture.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.Services
{
    public class UserService : 
        AbstractService<IUserRepository,UserModel,GetUserDto,CreateUserDto,UpdateUserDto>,
        IUserService
    {
        public UserService(ILogger logger, IMapper mapper, IUserRepository repository) : base(logger, mapper, repository)
        {
        }
        private string GenerateNewCode()
        {
            return new Random().Next().ToString();
        }
        public async Task GenerateNewEmailCodeForUser(string email)
        {
            var user = await repository.GetByEmail(email);
            if (user == null) throw new Exception("user is not exists"); var code = GenerateNewCode();
            user.EmailCode = code;
            var result = await repository.UpdateAsync(user);
        }

        public async Task GenerateNewResetPasswordCodeForUser(string email)
        {
            var user = await repository.GetByEmail(email);
        }

        public async Task<GetUserDto?> GetByEmail(string email)
        {
            var userModel = await repository.GetByEmail(email);
            if (userModel is null) logger.LogWarning($"User by Email {email} not found");
            return mapper.Map<GetUserDto?>(userModel);
        }

        public async Task<GetUserDto?> GetByEmailAndPassword(string email, string password)
        {
            var passwordHash = PasswordEnscryptService.Encrypt(password);
            var  user = await repository.GetByEmailAndPassword(email, passwordHash);
            if (user == null) logger.LogWarning($"user with {email} not exists");
            return mapper.Map<GetUserDto?>(user);

        }

        public async Task<GetUserDto> RegisterNewUser(string email,string login,string password)
        {
            var code = GenerateNewCode();
            var resetPass = GenerateNewCode();
            var newUser = new UserModel()
            {
                Name = login,
                Password = password,
                Email = email,
                EmailCode = code,
                IsEmailConfirmed = false,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow,
                IsDeleted = false,
                ResetPasswordCode = resetPass,
            };
            await repository.CreateAsync(newUser);
            await EmailSendler.SendConfirmationEmail(newUser);
            return mapper.Map<GetUserDto>(newUser);
        }

        public async Task<GetUserDto?> ResetPassword(string email, string emailCode, string newPassword)
        {
            var user = await repository.GetByEmail(email);
            if (user != null)
            {
                if (user.EmailCode == emailCode)
                {
                    user.Password = PasswordEnscryptService.Encrypt(newPassword);
                    await repository.UpdateAsync(user);
                }
            }
            return mapper.Map<GetUserDto>(user);
        }

        public async Task SendConfirmEmail(string email)
        {
            await GenerateNewEmailCodeForUser(email);
            var user = await repository.GetByEmail(email);
            if (user != null)
                await EmailSendler.SendConfirmationEmail(user);
        }

        public async Task SendResetCodeEmail(string email)
        {
            await GenerateNewResetPasswordCodeForUser(email);
            var user = await repository.GetByEmail(email);
            if (user != null)
                await EmailSendler.SendResetPasswordEmail(user);
        }

        public async Task<GetUserDto?> TryToConfirmEmail(string email, string emailCode)
        {
            var user = await repository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("user not exitst");
            }

            if (user.EmailCode == emailCode)
            {
                user.IsEmailConfirmed = true;
                await repository.UpdateAsync(user);
            }

            return mapper.Map<GetUserDto>(user);
        }
    }
}
