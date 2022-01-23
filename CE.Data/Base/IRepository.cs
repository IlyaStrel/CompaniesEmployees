using System;
using System.Collections.Generic;

namespace CE.Data.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();

        T GetById(int id);

        T GetById(Guid id);

        void Add(T item);

        void Update(T item);

        void Remove(T item);
    }
}