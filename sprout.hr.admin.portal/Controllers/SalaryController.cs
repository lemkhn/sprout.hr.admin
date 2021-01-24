namespace sprout.hr.admin.portal.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using sprout.hr.admin.core.BusinessLogic;
    using sprout.hr.admin.core.Model;
    using sprout.hr.admin.portal.Models;

    /// <summary>
    /// Instance of Salary Controller
    /// </summary>
    public class SalaryController : Controller
    {
        /// <summary>
        /// Initial action for salary controller
        /// </summary>
        /// <returns>return View</returns>
        public IActionResult Index()
        {
            try
            {
                string employeeType = Request.Cookies["employeeType"].ToString();

                EmployeeViewModel employeeViewModel = new EmployeeViewModel();

                employeeViewModel.TypeOfEmployee = employeeType;

                return View("Index", employeeViewModel);
            }
            catch
            {
                return Json(new { status = 2, message = "Something went wrong." });
            }
        }

        /// <summary>
        /// Post Method for calculating salary
        /// </summary>
        /// <param name="employeeTypeModel">Consits of Employee Details relevant for computing salary</param>
        /// <returns>returns custom response model with calculated employee salary</returns>
        [HttpPost]
        public object ComputeSalary(EmployeeTypeModel employeeTypeModel)
        {
            Employee employee = new Employee();

            ResponseModel responseModel = employee.ComputeSalary(employeeTypeModel);

            return JsonConvert.SerializeObject(responseModel, Formatting.None);
        }
    }
}