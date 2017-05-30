using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Update(TEntity obj);
        void SaveAll();
        void Add(TEntity obj);
        void Exclude(Func<TEntity, bool> predicate);

        //Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        //Task CreateAsync(TEntity contact, CancellationToken cancellationToken = default(CancellationToken));
        //Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
