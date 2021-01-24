namespace sprout.hr.admin.test
{
    using sprout.hr.admin.core.BusinessLogic;
    using sprout.hr.admin.core.Model;
    using Xunit;

    /// <summary>
    /// Unit test dedicated for Employee Type
    /// </summary>
    public class EmployeeTypeTest
    {
        private ResponseModel _responseModel;

        /// <summary>
        /// Testing Regular Employee Scenario
        /// </summary>
        [Fact]
        public void RegularEmployeeTest()
        {
            EmployeeTypeModel empTypeModel = new EmployeeTypeModel
            {
                EmployeeTypeName = "Regular",
                EmployeeRate = 20000M
            };

            Employee employee = new Employee();

            this._responseModel = employee.ComputeSalary(empTypeModel);
            empTypeModel = this._responseModel.Data as EmployeeTypeModel;

            Assert.True(empTypeModel.EmployeeSalary == 16690.91M);
        }

        /// <summary>
        /// Testing Contractual Employee Scenario
        /// </summary>
        [Fact]
        public void ContractualEmployeeTest()
        {
            EmployeeTypeModel empTypeModel = new EmployeeTypeModel
            {
                EmployeeTypeName = "Contractual",
                EmployeeRate = 500M,
                MonthWorkdays = 15.5M
            };

            Employee employee = new Employee();

            this._responseModel = employee.ComputeSalary(empTypeModel);
            empTypeModel = this._responseModel.Data as EmployeeTypeModel;

            Assert.True(empTypeModel.EmployeeSalary == 7750.00M);
        }

        /// <summary>
        /// Testing Catch Exception Employee Scenario
        /// </summary>
        [Fact]
        public void ExceptionEmployeeTest()
        {
            EmployeeTypeModel empTypeModel = new EmployeeTypeModel();

            Employee employee = new Employee();

            this._responseModel = employee.ComputeSalary(empTypeModel);
            empTypeModel = this._responseModel.Data as EmployeeTypeModel;

            Assert.Null(empTypeModel);
        }
    }
}