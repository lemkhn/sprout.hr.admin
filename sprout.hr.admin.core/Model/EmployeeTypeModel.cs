namespace sprout.hr.admin.core.Model
{
    /// <summary>
    /// Instance of Employee Type Model
    /// </summary>
    public class EmployeeTypeModel
    {
        /// <summary>
        /// Holds the default value for month workdays
        /// </summary>
        private decimal _monthWorkDays = 22.0M;

        /// <summary>
        /// Holds the default vlaue for employee tax
        /// </summary>
        private decimal _employeeTax = 0.12M;

        /// <summary>
        /// Gets or sets employment type name
        /// </summary>
        public string EmployeeTypeName { get; set; }

        /// <summary>
        /// Gets or sets employee's rate. Base on either monthly or daily rate
        /// </summary>
        public decimal EmployeeRate { get; set; }

        /// <summary>
        /// Gets or sets employies calculated salary
        /// </summary>
        public decimal EmployeeSalary { get; set; }

        /// <summary>
        /// Gets or sets count of workdays employee has rendered
        /// </summary>
        public decimal MonthWorkdays
        {
            get
            {
                return this._monthWorkDays;
            }
            set
            {
                if (!(value == 0))
                {
                    this._monthWorkDays = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets count of absences a regular employee has acquired
        /// </summary>
        public decimal AbsenceCount { get; set; }

        /// <summary>
        /// Gets or sets the tax for an employee
        /// </summary>
        public decimal EmployeeTax
        {
            get
            {
                return this._employeeTax;
            }
            set
            {
                if (!(value == 0))
                {
                    this._employeeTax = value;
                }
            }
        }
    }
}