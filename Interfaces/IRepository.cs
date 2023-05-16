using System.Collections.Generic;

namespace Crud.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();

         T ReturnById(int id);

         void Insert(T entity);

         void Remove(int id);

         void Update(int id, T entity);

         int NextId();
    }
}