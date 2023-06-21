using Autolote.Data;
using Autolote.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace Autolote.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AutoloteContext _db;
        internal DbSet<T> dbSet;

        public Repository(AutoloteContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
