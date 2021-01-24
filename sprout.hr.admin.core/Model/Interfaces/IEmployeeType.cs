namespace sprout.hr.admin.core.Model
{
    /// <summary>
    /// Interface for Employee Type
    /// </summary>
    public interface IEmployeeType
    {
        /// <summary>
        /// Gets or sets instance of Employee Type Model
        /// </summary>
        EmployeeTypeModel employeeType { get; set; }

        /// <summary>
        /// Calculates Salary of Employee
        /// </summary>
        /// <returns>Return update employee type model instance with calculated employee salary</returns>
        EmployeeTypeModel ComputeSalary();
    }
}