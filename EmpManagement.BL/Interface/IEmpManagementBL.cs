using EmpManagement.CL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagement.BL.Interface
{
    public interface IEmpManagementBL
    {
        // <summary>
        /// Interface method for Business layer GetAllEmployeeDetails
        /// </summary>
        /// <returns> SMD response </returns>
        ResponseMessage GetAllEmployeeDetails();

        /// <summary>
        /// Interface method for Business layer RegisterEmployee
        /// </summary>
        /// <param name="model"></param>
        /// <returns> SMD response </returns>
        ResponseMessage RegisterEmployee(EmployeeModel model);

        /// <summary>
        /// Interface method for Business layer EmployeeLogin
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns> SMD response </returns>
        ResponseMessage EmployeeLogin(LoginModel loginData);

        /// <summary>
        /// Interface method for Business layer GetEmployeeDetails
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns> SMD response </returns>
        ResponseMessage GetEmployeeDetails(string inputData);

        /// <summary>
        /// Interface method for Business layer GetEmployeeDetailsWithId
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns> SMD response </returns>
        ResponseMessage GetEmployeeDetailsWithId(EmployeeId inputData);

        /// <summary>
        /// Interface method for Business layer UpdateEmployeeDetails
        /// </summary>
        /// <param name="data"></param>
        /// <returns> SMD response </returns>
        ResponseMessage UpdateEmployeeDetails(UpdateModel data);

        /// <summary>
        /// Interface method for Business layer DeleteEmployee
        /// </summary>
        /// <param name="id"></param>
        /// <returns> SMD response </returns>
        ResponseMessage DeleteEmployee(EmployeeId id);
    }
}
