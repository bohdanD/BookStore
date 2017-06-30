using System.Collections.Generic;

namespace BookStore.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T Find(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
