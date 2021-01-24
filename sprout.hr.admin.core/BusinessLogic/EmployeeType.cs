namespace sprout.hr.admin.core.BusinessLogic
{
    using sprout.hr.admin.core.Model;

    /// <summary>
    /// The main structure for Types of Employee/s
    /// </summary>
    public abstract class EmployeeType : IEmployeeType
    {
        /// <summary>
        /// Holder of Employee Information
        /// </summary>
        public EmployeeTypeModel employeeType { get; set; }

        /// <summary>
        /// Declaring the base details for Employee Type
        /// </summary>
        /// <returns>Returns what specific  type was the employee</returns>
        protected EmployeeType(EmployeeTypeModel empTypeModel)
        {
            this.employeeType = empTypeModel;
        }

        /// <summary>
        /// Abstract function for computing employee salary
        /// </summary>
        /// <returns>return updated employee type model</returns>
        public abstract EmployeeTypeModel ComputeSalary();
    }
}