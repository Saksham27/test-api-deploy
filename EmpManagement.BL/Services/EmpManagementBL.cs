using EmpManagement.BL.Interface;
using EmpManagement.CL.Models;
using EmpManagement.RL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmpManagement.BL.Services
{
    public class EmpManagementBL : IEmpManagementBL
    {
        /// <summary>
        /// Instance of IEmployeeRL
        /// </summary>
        private readonly IEmpManagementRL employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBL"/> class.
        /// </summary>
        /// <param name="employeeRepo"> an instance of IEmployeeRL </param>
        public EmpManagementBL(IEmpManagementRL  employeeRepo)
        {
            this.employeeRepository = employeeRepo;
        }

        /// <summary>
        /// Get all employee details API
        /// </summary>
        /// <returns> SMD response </returns>
        #region GetAllEmployeeDetails
        public ResponseMessage GetAllEmployeeDetails()
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                List<DisplayAllDetails> data = employeeRepository.GetAllEmployeeDetails().ToList();
                if (data is null)
                {
                    response.Status = false;
                    response.Message = "Its lonely here. No employee exists.";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Here is all employees details.";
                    response.Data = data;
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Get employee data by providing any employee data API
        /// </summary>
        /// <param name="inputData"> string data </param>
        /// <returns> SMD response </returns>
        #region GetEmployeeDetails
        public ResponseMessage GetEmployeeDetails(string inputData)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                List<DisplayAllDetails> data = employeeRepository.GetEmployeeDetails(inputData).ToList();
                if (data.Count == 0)
                {
                    response.Status = false;
                    response.Message = "No such employee exists.";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Employee found. Here are the details";
                    response.Data = data;
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Get specific Employyee data by providing EmployeeId API
        /// </summary>
        /// <param name="inputData"> Employee Id instance </param>
        /// <returns> SMD response </returns>
        #region GetEmployeeDetailsWithId
        public ResponseMessage GetEmployeeDetailsWithId(EmployeeId inputData)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                List<DisplayAllDetails> data = employeeRepository.GetEmployeeDetailsWithId(inputData).ToList();
                if (data.Count == 0)
                {
                    response.Status = false;
                    response.Message = "No such employee exists.";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Employee found. Here are the details";
                    response.Data = data;
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Register Employee API
        /// </summary>
        /// <param name="data"> Employee model instance </param>
        /// <returns> SMD response </returns>
        #region RegisterEmployee
        public ResponseMessage RegisterEmployee(EmployeeModel data)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                int registrationStatus = employeeRepository.RegisterEmployee(data);
                if (registrationStatus > 0)
                {
                    response.Status = true;
                    response.Message = "Registration successful.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Registration failed. This Email Id or username already exists.";
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Employee Login API
        /// </summary>
        /// <param name="loginData"> Login model instance </param>
        /// <returns> SMD response </returns>
        #region EmployeeLogin
        public ResponseMessage EmployeeLogin(LoginModel loginData)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                int loginStatus = employeeRepository.EmployeeLogin(loginData);
                if (loginStatus == 1)
                {
                    response.Status = true;
                    response.Message = "Login successful.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Login failed.";
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Delete employee API
        /// </summary>
        /// <param name="id"> Employee Id instance </param>
        /// <returns> SMD response </returns>
        #region DeleteEmployee
        public ResponseMessage DeleteEmployee(EmployeeId id)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                int deletionStatus = employeeRepository.DeleteEmployee(id);
                if (deletionStatus == 1)
                {
                    response.Status = true;
                    response.Message = "employee data successfully deleted.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "No such employee exists.";
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion

        /// <summary>
        /// Update Employee data API
        /// </summary>
        /// <param name="data"> Update model instance </param>
        /// <returns> SMD response </returns>
        #region UpdateEmployeeDetails
        public ResponseMessage UpdateEmployeeDetails(UpdateModel data)
        {
            try
            {
                ResponseMessage response = new ResponseMessage();
                int updationStatus = employeeRepository.UpdateEmployeeDetails(data);
                if (updationStatus == 1)
                {
                    response.Status = true;
                    response.Message = "Employee details updated.";
                }
                else
                {
                    response.Status = false;
                    response.Message = "No such employee exists.";
                }

                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        #endregion
    }
}
