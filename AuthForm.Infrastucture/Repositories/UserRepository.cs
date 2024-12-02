using AuthForm.Infrastucture.Models;
using AuthForm.Infrastucture.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(AuthFormDbContext context) : base(context)
        {
        }
    }
}
