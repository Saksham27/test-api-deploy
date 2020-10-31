using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpManagement.CL.Models
{
    /// <summary>
    /// Poco class for Displaying all details
    /// </summary>
    #region DisplayAllDetails
    [Serializable]
    public class DisplayAllDetails
    {
        /// <summary>
        /// Gets or sets Employee Id
        /// </summary>
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
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }
    }
    #endregion
}
