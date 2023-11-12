using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagerAPI.Controllers;

public interface IBaseController<T> where T : class, IModel
{
    ActionResult<T> Get(int id);
    ActionResult<IEnumerable<T>> GetAll();
    ActionResult<T> Add(T model);
    ActionResult<T> Update(T model);
    ActionResult<T> Delete(int id);
}