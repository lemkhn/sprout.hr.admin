namespace sprout.hr.admin.core.Model
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Instance of Employee Model
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// List of Allowed Employee Types
        /// </summary>
        public enum TypesOfEmployee
        {
            Regular,
            Contractual
        }

        /// <summary>
        /// Gets or sets unique employee id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets employee name
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets date of birth
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets TIN number
        /// </summary>
        public string TinNumber { get; set; }

        /// <summary>
        /// Gets or sets salary of employee
        /// </summary>
        public decimal EmployeeSalary { get; set; }

        /// <summary>
        /// Gets or sets Employee Type
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypesOfEmployee EmployeeType { get; set; }
    }
}