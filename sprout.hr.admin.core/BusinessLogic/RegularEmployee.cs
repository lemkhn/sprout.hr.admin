namespace sprout.hr.admin.core.BusinessLogic
{
    using sprout.hr.admin.core.Model;
    using System;

    /// <summary>
    /// Employee Type Specific for Regular
    /// </summary>
    public class RegularEmployee : EmployeeType
    {
        // <summary>
        /// Creates new instance of <see cref="RegularEmployee"/> class
        /// </summary>
        /// <param name="employeeTypeModel">Holds all necessary information of the employee</param>
        public RegularEmployee(EmployeeTypeModel empTypeModel) : base(empTypeModel)
        {
            this.employeeType.MonthWorkdays = 22;
            this.employeeType.EmployeeTypeName = "Regular Employee";
        }

        /// <summary>
        /// Calculates the salary of a regular employee
        /// </summary>
        /// <returns>return update model with calculated salary</returns>
        public override EmployeeTypeModel ComputeSalary()
        {
            this.employeeType.EmployeeSalary = this.employeeType.EmployeeRate - (this.employeeType.EmployeeRate / this.employeeType.MonthWorkdays) - (this.employeeType.EmployeeRate * this.employeeType.EmployeeTax);

            this.employeeType.EmployeeSalary = Math.Round(this.employeeType.EmployeeSalary - ((this.employeeType.EmployeeRate / this.employeeType.MonthWorkdays) * this.employeeType.AbsenceCount), 2, MidpointRounding.AwayFromZero);

            return this.employeeType;
        }
    }
}