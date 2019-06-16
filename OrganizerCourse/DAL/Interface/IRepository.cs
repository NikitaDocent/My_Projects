using System;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);

        T Get(int id);
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Load();
    }
}
