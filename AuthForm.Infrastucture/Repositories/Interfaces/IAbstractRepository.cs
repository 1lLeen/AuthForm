using AuthForm.Infrastucture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture.Repositories.Interfaces
{
    public interface IAbstractRepository<TModel> where TModel : BaseModel
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<TModel> DeleteAsync(TModel model);
        Task<TModel> GetByIdAsync(int id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByEmail(string email);
        Task<TModel> GetByEmailAndPassword(string email, string password);
    }
}
