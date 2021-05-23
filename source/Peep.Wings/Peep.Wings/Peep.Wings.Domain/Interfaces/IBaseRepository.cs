using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Peep.Wings.Domain.Entities;

namespace Peep.Wings.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Insert(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        void Delete(int id);

        Task<IList<TEntity>> Get();

        Task<TEntity> Get(int id);
    }
}
