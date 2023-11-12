using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagerAPI.Controllers;

public class ProductController : BaseController<Product,ProductRepository>
{
    protected override ProductRepository Repo { get; set; } = new ProductRepository();
    
    [HttpGet("{name}")]
    public ActionResult<IEnumerable<Product>> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return Repo.GetAll();
        return Repo.GetAll().Where(x=>x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}