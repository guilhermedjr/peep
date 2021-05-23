using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Domain.Interfaces;

namespace Peep.Wings.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this._baseRepository = baseRepository;
        }

        public async Task<TEntity> Add<TValidator>(TEntity obj)
          where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) =>
            _baseRepository.Delete(id);

        public async Task<IList<TEntity>> Get() =>
            await _baseRepository.Get();

        public async Task<TEntity> GetById(int id) =>
            await _baseRepository.Get(id);

        public async Task<TEntity> Update<TValidator>(TEntity obj)
          where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Update(obj);
            return obj;
        }

        private static void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrowAsync(obj);
        }
    }
}
