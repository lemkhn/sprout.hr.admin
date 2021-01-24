namespace sprout.hr.admin.core.BusinessLogic.Factory
{
    using sprout.hr.admin.core.Model;

    /// <summary>
    ///  Class that only needed to be change when adding new employee Type.
    /// </summary>
    public class EmployeeTypeBuilder : EmployeeTypeFactory
    {
        /// <summary>
        ///  Creates the general logic behind the abstract method ChechEmployeeType
        /// </summary>
        /// <param name="employeeTypeModel">Holds all necessary information of the employee</param>
        /// <returns>Returns what specific  type was the employee</returns>
        protected override EmployeeType CheckEmployeeType(EmployeeTypeModel employeeTypeModel)
        {
            try
            {
                EmployeeType empType = null;

                if (employeeTypeModel.EmployeeTypeName.ToUpper().Equals("REGULAR"))
                {
                    empType = new RegularEmployee(employeeTypeModel);
                }
                else if (employeeTypeModel.EmployeeTypeName.ToUpper().Equals("CONTRACTUAL"))
                {
                    empType = new ContractualEmployee(employeeTypeModel);
                }
                else
                {
                    throw new System.Exception("Employee type was not yet enrolled in the application.");
                }

                return empType;
            }
            catch
            {
                throw new System.Exception("Application catch an error. Contact System Administrator for support. Thank you!");
            }
        }
    }
}