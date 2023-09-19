﻿
namespace Mwh.Sample.Web.Controllers;

/// <summary>
/// EmployeeController
/// </summary>
public class EmployeeController : BaseController
{
    /// <summary>
    ///
    /// </summary>
    private readonly IEmployeeClient client;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="employeeClient"></param>
    /// <param name="configuration"></param>
    /// <param name="hostEnvironment"></param>
    public EmployeeController(IEmployeeClient employeeClient, IConfiguration configuration, IWebHostEnvironment hostEnvironment) : base(configuration, hostEnvironment)
    {
        client = employeeClient;
    }

    /// <summary>
    /// GetEmployeeDelete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("Employee/GetEmployeeDelete/{id}")]
    public async Task<ActionResult> GetEmployeeDelete(int id = 0)
    {
        var employee = await client.FindEmployeeByIdAsync(id, cts.Token);
        return PartialView("_EmployeeDelete", employee.Resource);
    }
    /// <summary>
    /// GetEmployeeDelete
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employee"></param>
    /// <returns></returns>[HttpPost]
    [HttpPost]
    [Route("Employee/GetEmployeeDelete/{id}")]
    public async Task<ActionResult> GetEmployeeDelete(int? id = null, EmployeeDto? employee = null)
    {
        if (employee != null)
            employee.Id = id ?? 0;

        var response = await client.DeleteAsync(id ?? 0, cts.Token);
        return Redirect("/Employee");
    }
    /// <summary>
    /// GetEmployeeEdit
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> GetEmployeeEdit(int id = 0)
    {
        var employee = await client.FindEmployeeByIdAsync(id, cts.Token);

        return PartialView("_EmployeeEdit", employee?.Resource);


    }

    /// <summary>
    /// GetEmployeeList
    /// </summary>
    /// <param name="paging"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> GetEmployeeList(PagingParameterModel? paging)
    {
        if (paging == null)
            paging = new PagingParameterModel();

        var list = await client.GetEmployeesAsync(paging, cts.Token);
        return PartialView("_EmployeeList", list);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employee"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut]
    [HttpPost]
    [Route("Employee/GetEmployeeEdit/{id}")]
    public async Task<ActionResult> GetEmployeeEdit(int? id = null, EmployeeDto? employee = null, CancellationToken token = default)
    {
        if (employee != null)
            employee.Id = id ?? 0;

        var response = await client.SaveAsync(employee, token);
        return Redirect("/Employee");
    }
    /// <summary>
    /// Default Page for Employee Controller
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult Index() { return View(); }
}
