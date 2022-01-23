using CE.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CE.EFC.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly ApplicationContext _context;
        readonly DbSet<T> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public T GetById(int id)
        {
            if (id == 0)
                return null;

            T result = _dbSet.Find(id);

            return result;
        }

        public T GetById(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            T result = _dbSet.Find(id);

            return result;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}