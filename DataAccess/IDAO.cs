using BusinessObject;

namespace DataAccess;

public interface IDAO<T> where T : class, IModel
{
    static abstract T? Get(int id);
    static abstract T? Get(params object[] keys);
    static abstract T? Get(T model);
    static abstract List<T> GetAll();
    static abstract void Add(T model);
    static abstract void Update(T model);
    static abstract void Delete(int id);
    static abstract void Delete(T model);
}