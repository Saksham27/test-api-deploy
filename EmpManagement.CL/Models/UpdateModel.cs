using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpManagement.CL.Models
{
    /// <summary>
    /// Poco class for update model
    /// </summary>
    #region UpdateModel
    public class UpdateModel
    {
        /// <summary>
        /// Gets or sets Employee Id
        /// </summary>
        [Required(ErrorMessage = "EmployeeId Is Required")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets FirstName
        /// </summary>   
        [Required(ErrorMessage = "FirstName Is Required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        [Required(ErrorMessage = "LastName Is Required")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        [PasswordPropertyText]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        [Required(ErrorMessage = "City Is Required")]
        public string City { get; set; }
    }
    #endregion
}
