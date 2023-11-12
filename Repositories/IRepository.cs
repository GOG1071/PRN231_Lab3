using BusinessObject;

namespace Repositories;

public interface IRepository<T> where T : class, IModel
{
    void Add(T model);
    void Update(T model);
    void Delete(int id);
    T? Get(int id);
    T? Get(params object[] keys);
    T? Get(T model);
    List<T> GetAll();
}