using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpManagement.CL.Models
{
    #region LoginModel
    /// <summary>
    /// POCO class for Login
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
    #endregion
}
