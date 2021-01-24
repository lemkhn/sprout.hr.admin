namespace sprout.hr.admin.core.BusinessLogic
{
    using sprout.hr.admin.core.BusinessLogic.Factory;
    using sprout.hr.admin.core.Model;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Methods and properties for Employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Custom Response Model
        /// </summary>
        private ResponseModel _response = null;

        /// <summary>
        /// List of Employees
        /// </summary>
        private List<EmployeeModel> _employees = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        public Employee()
        {
            //! Since I'm not using database, i am creating an initial data for display.
            this._employees = new List<EmployeeModel>();

            this._employees.Add(new EmployeeModel
            {
                EmployeeId = 1,
                EmployeeName = "Solem Khan",
                TinNumber = "1234567890",
                BirthDate = "09/02/1994",
                EmployeeType = EmployeeModel.TypesOfEmployee.Regular,
                EmployeeSalary = 20000M
            });
            this._employees.Add(new EmployeeModel
            {
                EmployeeId = 2,
                EmployeeName = "Don Juan",
                TinNumber = "3214567890",
                BirthDate = "09/02/1994",
                EmployeeType = EmployeeModel.TypesOfEmployee.Contractual,
                EmployeeSalary = 18000M
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        /// <param name="employeeList">List of Employees from UI</param>
        public Employee(List<EmployeeModel> employeeList)
        {
            //! Since I'm not using database, i saved all my data in browser's localStorage.
            this._employees = new List<EmployeeModel>();

            this._employees = employeeList;
        }

        /// <summary>
        /// Retrives list of all employees
        /// </summary>
        /// <returns>Returns all saved employees</returns>
        public ResponseModel GetEmployees()
        {
            this._response = new ResponseModel();

            try
            {
                this._response.Status = 1;
                this._response.Data = this._employees;
            }
            catch (Exception ex)
            {
                this._response.Status = 2;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        /// <summary>
        /// Retrives specific employee from all employees
        /// </summary>
        /// <param name="employeeId">Employee Unique Id</param>
        /// <returns>Returns specific employee</returns>
        public ResponseModel GetSpecificEmployee(int employeeId)
        {
            this._response = new ResponseModel();

            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                employeeModel = this._employees.Find(data => data.EmployeeId == employeeId);

                this._response.Status = 1;
                this._response.Data = employeeModel;
            }
            catch (Exception ex)
            {
                this._response.Status = 2;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        /// <summary>
        /// Adds new Employee in the List
        /// </summary>
        /// <param name="employeeDtl">Contains Employee details</param>
        /// <returns>Returns list of updated employees for redrawing datatable</returns>
        public ResponseModel AddEmployee(EmployeeModel employeeDtl)
        {
            this._response = new ResponseModel();

            try
            {
                employeeDtl.EmployeeId = this._employees.Count + 1;

                this._employees.Add(employeeDtl);

                this._response.Status = 1;
                this._response.Data = this._employees;
            }
            catch (Exception ex)
            {
                this._response.Status = 2;
                this._response.Message = ex.Message;
            }

            return this._response;
        }

        /// <summary>
        /// Computes the Employees Salary base on user inputs
        /// </summary>
        /// <param name="empTypeModel">Contains detailes regarding employee</param>
        /// <returns>Returns the computed salary of the employee</returns>
        public ResponseModel ComputeSalary(EmployeeTypeModel empTypeModel)
        {
            this._response = new ResponseModel();

            try
            {
                EmployeeTypeFactory empTypeFact = new EmployeeTypeBuilder();

                EmployeeType employeeType = empTypeFact.EvaluateEmployee(empTypeModel);

                this._response.Status = 1;
                this._response.Data = employeeType.ComputeSalary();
            }
            catch (Exception ex)
            {
                this._response.Status = 2;
                this._response.Message = ex.Message;
            }

            return this._response;
        }
    }
}