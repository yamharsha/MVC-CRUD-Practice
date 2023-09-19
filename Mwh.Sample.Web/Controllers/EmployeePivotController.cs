﻿namespace Mwh.Sample.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeePivotController : BaseController
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
        public EmployeePivotController(IEmployeeClient employeeClient, IConfiguration configuration,
        IWebHostEnvironment hostEnvironment) : base(configuration, hostEnvironment)
        {
            client = employeeClient;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GetEmployeeList
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {

            var paging = new PagingParameterModel
            {
                PageSize = 3000,
                PageNumber = 1
            };

            var list = await client.GetEmployeesAsync(paging, cts.Token);
            return PartialView("_EmployeeList", list);
        }



    }
}
