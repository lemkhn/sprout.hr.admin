namespace sprout.hr.admin.core.BusinessLogic
{
    using sprout.hr.admin.core.Model;
    using System;

    /// <summary>
    /// Employee Type Specific for Contractual
    /// </summary>
    public class ContractualEmployee : EmployeeType
    {
        /// <summary>
        /// Creates new instance of <see cref="ContractualEmployee"/> class
        /// </summary>
        /// <param name="employeeTypeModel">Holds all necessary information of the employee</param>
        public ContractualEmployee(EmployeeTypeModel empTypeModel) : base(empTypeModel)
        {
            this.employeeType.EmployeeTypeName = "Contractual Employee";
        }

        /// <summary>
        /// Calculates the salary of a contractual employee
        /// </summary>
        /// <returns>return update model with calculated salary</returns>
        public override EmployeeTypeModel ComputeSalary()
        {
            this.employeeType.EmployeeSalary = Math.Round(this.employeeType.EmployeeRate * this.employeeType.MonthWorkdays, 2, MidpointRounding.AwayFromZero);

            return this.employeeType;
        }
    }
}