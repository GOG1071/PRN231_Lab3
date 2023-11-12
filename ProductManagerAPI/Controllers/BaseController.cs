using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController<TModel, TRepo> : ControllerBase, IBaseController<TModel>
    where TModel : class, IModel where TRepo : IRepository<TModel>
{
    protected abstract TRepo Repo { get; set; }

    [HttpGet("{id:int}")]
    public virtual ActionResult<TModel> Get(int id)
    {
        var checkedModel = Repo.Get(id);
        if (checkedModel == null)
        {
            return NotFound();
        }
        return checkedModel;
    }

    [HttpGet]
    public virtual ActionResult<IEnumerable<TModel>> GetAll()
    {
        return Repo.GetAll();
    }

    [HttpPost]
    public virtual ActionResult<TModel> Add(TModel model)
    {
        var checkedModel = Repo.Get(model);
        if (checkedModel != null)
        {
            return BadRequest("Model already exists");
        }

        Repo.Add(model);
        return NoContent();
    }

    [HttpPut]
    public virtual ActionResult<TModel> Update(TModel model)
    {
        var checkedModel = Repo.Get(model);
        if (checkedModel == null)
        {
            return NotFound();
        }

        Repo.Update(model);
        return NoContent();
    }

    [HttpDelete]
    public virtual ActionResult<TModel> Delete(int id)
    {
        var checkedModel = Repo.Get(id);
        if (checkedModel == null)
        {
            return NotFound();
        }

        Repo.Delete(id);
        return NoContent();
    }
}