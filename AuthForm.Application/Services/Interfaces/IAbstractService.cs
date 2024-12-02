using AuthForm.Dto.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.Services.Interfaces
{
    public interface IAbstractService<TGet, TCreate, TUpdate>
       where TGet : IGet
       where TCreate : ICreate
       where TUpdate : IUpdate
    {
        Task<IEnumerable<TGet>> GetAllAsync();
        Task<TGet> GetByIdAsync(int id);
        Task<TGet> CreateAsync(TCreate dto);
        Task<TGet> UpdateAsync(TUpdate dto);
        Task<TGet> DeleteAsync(int id);
    }
}
