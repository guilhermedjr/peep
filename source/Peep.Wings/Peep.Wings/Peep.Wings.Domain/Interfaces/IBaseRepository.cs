using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Peep.Wings.Domain.Entities;

namespace Peep.Wings.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);

        Task<IList<TEntity>> Get();

        Task<TEntity> Get(int id);
    }
}
