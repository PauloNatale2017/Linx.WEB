using Linx.Domain.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {

        private readonly Linx.DataAccessLayer.dbContext.dbContext _ctx;

        public Repository(Linx.DataAccessLayer.dbContext.dbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return _ctx.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            _ctx.Set<TEntity>().Attach(obj);
            _ctx.Entry(obj).State = EntityState.Modified;
            //_ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SaveAll()
        {
            _ctx.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            _ctx.Set<TEntity>().Add(obj);
        }

        public void Exclude(Func<TEntity, bool> predicate)
        {
            _ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _ctx.Set<TEntity>().Remove(del));
        }


        //metodos assinconos
        //public async Task<List<TEntity>> GetAllAsync()
        //{
        //    return await _ctx.Set<TEntity>().ToListAsync();
        //}
        //public async Task CreateAsync(TEntity contact, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //        ctx.Set<TEntity>().Add(contact);
        //        await ctx.SaveChangesAsync(cancellationToken);           
        //}
        //public async Task DeleteAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        //{           
        //        var entity = await ctx.Set<TEntity>().FindAsync(cancellationToken, id);
        //        ctx.Set<TEntity>().Remove(entity);
        //        await ctx.SaveChangesAsync(cancellationToken);           
        //}

        public void Dispose()
        {
            _ctx.Dispose();
        }

    }
}
