using System.Text.Json;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace IdentityAjaxClient.Controllers;

public abstract class BaseController<TModel, TRepo> : Controller, IBaseController<TModel> where TModel : class, IModel
    where TRepo : class, IRepository<TModel>
{
    protected HttpClient _httpClient = null;
    protected TRepo repo;

    #region URLs

    protected string _baseUrl = "";
    protected string _apiGetUrl = "GetAll";
    protected string _apiPostUrl = "Add";
    protected string _apiPutUrl = "Update";
    protected string _apiDeleteUrl = "Delete";
    protected string _apiGetByIdUrl = "Get";
    protected string redirectURI = "Index";

    #endregion


    #region GET

    public virtual async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync(_baseUrl+(_baseUrl[^1] != '/' ? "/" : "")+_apiGetUrl);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<TModel>>(jsonString);
            return View(list);
        }
        return View();
    }

    public virtual async Task<IActionResult> Detail(int id)
    {
        if (id == null || id <= 0)
            return NotFound();
        var response = await _httpClient.GetAsync(_baseUrl+(_baseUrl[^1] != '/' ? "/" : "")+_apiGetByIdUrl+"/"+id);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<TModel>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (model == null)
                return NotFound();
            return View(model);
        }
        else
        {
            return this.BadRequest();
        }
    }

    public virtual async Task<IActionResult> Create()
    {
        return View();
    }

    public async Task<IActionResult>  Delete(int id)
    {
        if (id == null || id <= 0)
            return NotFound();
        var response = await _httpClient.GetAsync(_baseUrl+(_baseUrl[^1] != '/' ? "/" : "")+_apiGetByIdUrl+"/"+id);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<TModel>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (model == null)
                return NotFound();
            return View(model);
        }
        else
        {
            return this.BadRequest();
        }
    }

    public virtual async Task<IActionResult> Edit(int id)
    {
        if (id == null || id <= 0)
            return NotFound();
        var response = await _httpClient.GetAsync(_baseUrl+(_baseUrl[^1] != '/' ? "/" : "")+_apiGetByIdUrl+"/"+id);
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<TModel>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (model == null)
                return NotFound();
            return View(model);
        }
        else
        {
            return this.BadRequest();
        }
    }

    #endregion

    #region POST

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel obj)
    {
        repo.Add(obj);
        return RedirectToAction(this.redirectURI);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TModel obj)
    {
        repo.Update(obj);
        return RedirectToAction(this.redirectURI);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(TModel obj)
    {
        repo.Delete(obj.Id);
        return RedirectToAction(this.redirectURI);
    }

    #endregion
}