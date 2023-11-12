using BusinessObject;
using DataAccess;

namespace Repositories;

public abstract class Repository<TModel, TDAO> : IRepository<TModel> where TModel : class, IModel where TDAO : IDAO<TModel>
{
    public virtual void Add(TModel model)
    {
        TDAO.Add(model);
    }

    public virtual void Update(TModel model)
    {
        TDAO.Update(model);
    }

    public virtual void Delete(int id)
    {
        TDAO.Delete(id);
    }

    public virtual TModel Get(int id)
    {
        return TDAO.Get(id);
    }

    public TModel Get(params object[] keys)
    {
        return TDAO.Get(keys);
    }

    public TModel Get(TModel model)
    {
        return TDAO.Get(model);
    }

    public virtual List<TModel> GetAll()
    {
        return TDAO.GetAll();
    }
}