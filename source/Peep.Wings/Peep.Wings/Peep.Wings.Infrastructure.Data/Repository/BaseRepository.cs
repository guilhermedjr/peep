using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Domain.Interfaces;
using Peep.Wings.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Peep.Wings.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<TEntity> Insert(TEntity obj)
        {
            _appDbContext.Set<TEntity>().Add(obj);
            await _appDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            _appDbContext.Entry(obj).State = EntityState.Modified;
           await  _appDbContext.SaveChangesAsync();
            return obj;
        }

        public async void Delete(int id)
        {
             _appDbContext.Set<TEntity>().Remove(await Get(id));
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> Get() =>
            await _appDbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> Get(int id) =>
            await _appDbContext.Set<TEntity>().FindAsync(id);

    }
}
