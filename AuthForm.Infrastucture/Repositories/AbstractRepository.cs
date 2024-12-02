using AuthForm.Infrastucture.Models;
using AuthForm.Infrastucture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture.Repositories
{
    public class AbstractRepository : IAbstractRepository<UserModel>
    {
        protected readonly AuthFormDbContext _context;
        protected readonly DbSet<UserModel> _users;
        public AbstractRepository(AuthFormDbContext context) 
        {
            _context = context;
            _users = _context.Set<UserModel>();
        } 
        public async Task<UserModel> CreateAsync(UserModel model)
        {
            model.CreatedTime = DateTime.Now;
            model.UpdatedTime = DateTime.Now;
            model.IsDeleted = false;
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<UserModel> DeleteAsync(UserModel model)
        {
            _context.Remove(model);
            await Task.CompletedTask;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync() => (IEnumerable<UserModel>)await _users.ToListAsync();

        public async Task<UserModel> GetByIdAsync(int id) => await _users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<UserModel> UpdateAsync(UserModel model)
        {
            model.UpdatedTime = DateTime.Now;
            var entry = _context.Entry(model);
            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<UserModel> GetByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<UserModel> GetByEmailAndPassword(string email, string password)
        {
            return await _users.FirstOrDefaultAsync
                (
                x =>
                x.Email == email && x.Password == password
                );
        }
    }
}
