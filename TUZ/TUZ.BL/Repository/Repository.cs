using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;

namespace TUZ.BL.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _db;

        public Repository(SQLiteAsyncConnection db)
        {
            _db = db;
            _db.CreateTableAsync<T>();
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _db.Table<T>();
        }

        public async Task<List<T>> Get()
        {
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<List<T>> Get<TValue>(
            Expression<Func<T, bool>> predicate = null, 
            Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.FindAsync(predicate);
        }

        public async Task<int> Insert(T entity)
        {
            return await _db.InsertAsync(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _db.UpdateAsync(entity);
        }

        public async Task<int> Delete(T entity)
        {
            return await _db.DeleteAsync(entity);
        }
    }
}
