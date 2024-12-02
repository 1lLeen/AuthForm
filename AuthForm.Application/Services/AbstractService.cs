using AuthForm.Application.Services.Interfaces;
using AuthForm.Dto.Dtos.Interfaces;
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
    public class AbstractService<TRepository, TModel, TGet, TCreate, TUpdate>
        where TRepository : IAbstractRepository<TModel>
        where TModel : BaseModel
        where TGet : IGet
        where TCreate : ICreate
        where TUpdate : IUpdate
    {

        protected readonly TRepository repository;
        protected readonly ILogger logger;
        protected readonly IMapper mapper;
        public AbstractService(ILogger logger, IMapper mapper, TRepository repository)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<TGet> CreateAsync(TCreate create)
        {
            var model = mapper.Map<TModel>(create);
            model.UpdatedTime = DateTime.Now;
            model.CreatedTime = DateTime.Now;
            model.IsDeleted = false;
            model = await repository.CreateAsync(model);
            var res = mapper.Map<TGet>(model);
            return res;
        }

        public async Task<TGet> DeleteAsync(int id)
        {
            var delete = await repository.GetByIdAsync(id);
            var model = mapper.Map<TModel>(delete);
            if (model == null) throw new ArgumentNullException("model");
            if (model.IsDeleted) throw new ArgumentException("model already deleted");
            if (repository.GetByIdAsync(model.Id) == null) throw new ArgumentException("model not found");

            model.IsDeleted = true;
            await repository.DeleteAsync(model);
            var result = mapper.Map<TGet>(model);
            return result;
        }

        public async Task<IEnumerable<TGet>> GetAllAsync()
        {
            if (repository == null) throw new ArgumentNullException("repos is null");
            var res = mapper.Map<IEnumerable<TGet>>(await repository.GetAllAsync());
            return res;
        }

        public async Task<TGet> GetByIdAsync(int id)
        {
            if(id == 0) throw new ArgumentNullException("id is 0");
            var res = mapper.Map<TGet>(await repository.GetByIdAsync(id));
            return res;
        }

        public async Task<TGet> UpdateAsync(TUpdate update)
        {
            var model = mapper.Map<TModel>(update);
            if (model == null) throw new ArgumentNullException("model is null");
            if (model.IsDeleted) throw new ArgumentException("model is deleted");
            var res = mapper.Map<TGet>(await repository.UpdateAsync(model));
            return res;
        }
    }
}
