using EmpManagement.CL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagement.RL.Interface
{
    public interface IEmpManagementRL
    {
        /// <summary>
        /// Interface method for Employee Registration
        /// </summary>
        /// <param name="model"> employee model </param>
        /// <returns> registration status </returns>
        int RegisterEmployee(EmployeeModel model);

        /// <summary>
        /// Interface method for Employee Login
        /// </summary>
        /// <param name="loginData"> login model </param>
        /// <returns> login status </returns>
        int EmployeeLogin(LoginModel loginData);

        /// <summary>
        /// Interface method for delete Employee detail
        /// </summary>
        /// <param name="Data"> employee id </param>
        /// <returns> delete employee status </returns>
        int DeleteEmployee(EmployeeId Data);

        /// <summary>
        /// Interface method for update Employee detail
        /// </summary>
        /// <param name="data"> update model </param>
        /// <returns> update status </returns>
        int UpdateEmployeeDetails(UpdateModel data);

        /// <summary>
        /// Interface method for get Employee detail 
        /// </summary>
        /// <param name="inputData"> input data </param>
        /// <returns> list of data </returns>
        IEnumerable<DisplayAllDetails> GetEmployeeDetails(string inputData);

        /// <summary>
        /// Interface method for get Employee detail 
        /// </summary>
        /// <param name="inputData"> employee id </param>
        /// <returns> returned list data </returns>
        IEnumerable<DisplayAllDetails> GetEmployeeDetailsWithId(EmployeeId inputData);

        /// <summary>
        /// Interface method for get all Employee detail
        /// </summary>
        /// <returns> data list </returns>
        IEnumerable<DisplayAllDetails> GetAllEmployeeDetails();
    }
}
