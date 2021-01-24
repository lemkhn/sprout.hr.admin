namespace sprout.hr.admin.portal.Models
{
    using sprout.hr.admin.core.Model;

    /// <summary>
    /// Instance of Employee Model for View
    /// </summary>
    public class EmployeeViewModel : EmployeeModel
    {
        /// <summary>
        /// Gets or sets type of employee for view conditioning
        /// </summary>
        public string TypeOfEmployee { get; set; }
    }
}