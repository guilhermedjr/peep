using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Peep.Wings.Domain.Entities;

namespace Peep.Wings.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        Task<IList<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
