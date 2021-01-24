namespace sprout.hr.admin.portal.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using sprout.hr.admin.core.BusinessLogic;
    using sprout.hr.admin.core.Model;
    using sprout.hr.admin.portal.Models;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Instance of Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <inheritdoc/>
        private ResponseModel _responseModel = null;

        /// <summary>
        /// Initial action for home controller
        /// </summary>
        /// <returns>return View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Default error handler for salary controller
        /// </summary>
        /// <returns>return View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>returns serialize object of <see cref="ResponseModel"/> class</returns>
        [HttpGet]
        public object GetEmployees()
        {
            Employee employee = new Employee();

            this._responseModel = employee.GetEmployees();

            return JsonConvert.SerializeObject(this._responseModel, new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        /// <summary>
        /// Gets specific employees
        /// </summary>
        /// <param name="employeeList">Contains updated list of employees from localstorage</param>
        /// <param name="employeeId">Specific Employee to locate</param>
        /// <returns>returns serialize object of <see cref="ResponseModel"/> class</returns>
        [HttpPost]
        public object GetEmployee(List<EmployeeModel> employeeList, int employeeId)
        {
            Employee employee = new Employee(employeeList);

            this._responseModel = employee.GetSpecificEmployee(employeeId);

            return JsonConvert.SerializeObject(this._responseModel, new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        /// <summary>
        /// Adds specific employee
        /// </summary>
        /// <param name="employeeDtl">Details of specific employee</param>
        /// <param name="employeeList">Contains updated list of employees from localstorage</param>
        /// <returns>returns serialize object of <see cref="ResponseModel"/> class</returns>
        [HttpPost]
        public object AddEmployee(EmployeeModel employeeDtl, List<EmployeeModel> employeeList)
        {
            Employee employee = new Employee(employeeList);

            this._responseModel = employee.AddEmployee(employeeDtl);

            return JsonConvert.SerializeObject(this._responseModel, new Newtonsoft.Json.Converters.StringEnumConverter());
        }
    }
}