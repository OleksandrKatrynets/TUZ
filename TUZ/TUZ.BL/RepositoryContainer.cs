using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TUZ.BL.Repository;

namespace TUZ.BL
{
    public class RepositoryContainer
    {
        private readonly SQLiteAsyncConnection _dbConnection;
        private readonly Dictionary<Type, object> _repositories;

        public RepositoryContainer(SQLiteAsyncConnection dbConnection)
        {
            _repositories = new Dictionary<Type, object>();
            _dbConnection = dbConnection;
        }
        
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            var repository = new Repository<T>(_dbConnection);
            _repositories.Add(typeof(T), repository);
            
            return repository;
        }
    }
}