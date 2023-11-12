using BusinessObject;
using Repositories;

namespace ProductManagerAPI.Controllers;

public class CategoryController : BaseController<Category, CategoryRepository>
{
    protected override CategoryRepository Repo { get; set; } = new CategoryRepository();
}