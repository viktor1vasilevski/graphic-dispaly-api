using Data.Context;
using EntityModels.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly LibraryDbContext _dbContext;
        public BaseRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
