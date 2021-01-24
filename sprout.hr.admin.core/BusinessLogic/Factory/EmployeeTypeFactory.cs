namespace sprout.hr.admin.core.BusinessLogic.Factory
{
    using sprout.hr.admin.core.Model;

    /// <summary>
    /// Employee Type Abstract Factory
    /// </summary>
    public abstract class EmployeeTypeFactory
    {
        /// <summary>
        /// Extended to EmployeeType Builder
        /// </summary>
        /// <param name="employeeTypeModel">Holds all necessary information of the employee</param>
        /// <returns>Returns what specific  type was the employee</returns>
        protected abstract EmployeeType CheckEmployeeType(EmployeeTypeModel employeeTypeModel);

        /// <summary>
        /// Method to call to evaluate the type of employee
        /// </summary>
        /// <param name="employeeTypeModel">Holds all necessary information of the employee</param>
        /// <returns>Returns what specific  type was the employee</returns>
        public EmployeeType EvaluateEmployee(EmployeeTypeModel employeeTypeModel)
        {
            EmployeeType employeeType = this.CheckEmployeeType(employeeTypeModel);

            return employeeType;
        }
    }
}