using System.Net.Http.Headers;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace IdentityAjaxClient.Controllers;

public class ProductController : BaseController<Product, ProductRepository>
{
    
    public ProductController()
    {
        this._httpClient = new();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        this._httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        this._baseUrl = "http://localhost:5164/api/Product";
        this.redirectURI = "Index";
        this.repo = new ProductRepository();
    }

    public override async Task<IActionResult> Index()
    {
        return View();
    }
}