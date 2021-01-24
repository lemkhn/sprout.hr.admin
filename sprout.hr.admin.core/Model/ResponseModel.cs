namespace sprout.hr.admin.core.Model
{
    /// <summary>
    /// Instance of Response Model Model
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Gets or sets predefined status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets custom return data dolder
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or Sets custom response message
        /// </summary>
        public string Message { get; set; }
    }
}