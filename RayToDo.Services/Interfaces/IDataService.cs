using System.Collections.Generic;

namespace RayToDo.Services.Interfaces
{
    public interface IDataService<T> : IService where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void DeleteById(int id);
    }
}