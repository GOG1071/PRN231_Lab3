using BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAjaxClient.Controllers;

public interface IBaseController<T> where T : class, IModel
{
    #region GET

    Task<IActionResult> Index();
    Task<IActionResult> Detail(int id);
    Task<IActionResult> Create();
    Task<IActionResult> Delete(int id);
    Task<IActionResult> Edit(int id);

    #endregion

    #region POST

    Task<IActionResult> Create(T obj);
    Task<IActionResult> Edit(T obj);
    Task<IActionResult> Delete(T obj);

    #endregion
}