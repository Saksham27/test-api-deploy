using EmpManagement.CL.Models;
using EmpManagement.RL.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmpManagement.RL.Services
{
    public class EmpManagementRL : IEmpManagementRL
    {
        private readonly IConfiguration configuration;

        public EmpManagementRL(IConfiguration configure)
        {
            configuration = configure;
        }

        /// <summary>
        /// API to get all employee details
        /// </summary>
        /// <returns></returns>
        #region GetAllEmployeeDetails
        public IEnumerable<DisplayAllDetails> GetAllEmployeeDetails()
        {
            List<DisplayAllDetails> listEmployee = new List<DisplayAllDetails>();
            SqlConnection connection = DatabaseConnection();
            SqlCommand command = StoreProcedureConnection("spGetUsers", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisplayAllDetails employee = new DisplayAllDetails
                {
                    EmployeeId = Convert.ToInt32(reader["UserId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    City = reader["City"].ToString()
                };
                listEmployee.Add(employee);
            }
            connection.Close();
            return listEmployee;
        }
        #endregion GetAllEmployeeDetails

        /// <summary>C:\Users\Saksham\source\repos\UserLogin.Api\UserLogin.RL\Services\EmployeeDataRL.cs
        /// API to register Employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns> if operation is successful or not </returns>
        #region RegisterEmployee
        public int RegisterEmployee(EmployeeModel model)
        {
            SqlConnection connection = DatabaseConnection();

            try
            {
                string encrptedPassword = PasswordEncryptDecrypt.EncodePasswordToBase64(model.Password);
                SqlCommand command = StoreProcedureConnection("spRegisterUser", connection);
                command.Parameters.AddWithValue("FirstName", model.FirstName);
                command.Parameters.AddWithValue("LastName", model.LastName);
                command.Parameters.AddWithValue("Email", model.Email);
                command.Parameters.AddWithValue("UserName", model.UserName);
                command.Parameters.AddWithValue("Password", encrptedPassword);
                command.Parameters.AddWithValue("City", model.City);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion RegisterEmployee

        /// <summary>
        /// API to Get details of specfic employee
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        #region GetEmployeeDetails
        public IEnumerable<DisplayAllDetails> GetEmployeeDetails(string inputData)
        {
            List<DisplayAllDetails> listEmployee = new List<DisplayAllDetails>();
            SqlConnection connection = DatabaseConnection();
            SqlCommand command = StoreProcedureConnection("spGetUserDetail", connection);
            command.Parameters.Add("@Data", SqlDbType.VarChar, 50).Value = inputData;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisplayAllDetails employee = new DisplayAllDetails
                {
                    EmployeeId = Convert.ToInt32(reader["UserId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    City = reader["City"].ToString()
                };
                listEmployee.Add(employee);
            }
            connection.Close();
            return listEmployee;
        }
        #endregion GetEmployeeDetails

        /// <summary>
        /// API to details of specfid employee with Id
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        #region GetEmployeeDetailsWithId
        public IEnumerable<DisplayAllDetails> GetEmployeeDetailsWithId(EmployeeId inputData)
        {
            List<DisplayAllDetails> listEmployee = new List<DisplayAllDetails>();
            SqlConnection connection = DatabaseConnection();
            SqlCommand command = StoreProcedureConnection("spGetUserDetailWithId", connection);
            command.Parameters.Add("@Id", SqlDbType.Int, 50).Value = inputData.ID;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DisplayAllDetails employee = new DisplayAllDetails
                {
                    EmployeeId = Convert.ToInt32(reader["UserId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    City = reader["City"].ToString()
                };
                listEmployee.Add(employee);
            }
            connection.Close();
            return listEmployee;
        }
        #endregion GetEmployeeDetailsWithId

        /// <summary>
        /// API to Delete employee from databse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        #region DeleteEmployee
        public int DeleteEmployee(EmployeeId inputId)
        {
            SqlConnection connection = DatabaseConnection();
            try
            {
                SqlCommand command = StoreProcedureConnection("spDeleteUserDetail", connection);
                command.Parameters.Add("@Id", SqlDbType.Int, 50).Value = inputId.ID;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion DeleteEmployee

        /// <summary>
        /// API for employee Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        #region Login
        public int EmployeeLogin(LoginModel loginData)
        {
            SqlConnection connection = DatabaseConnection();
            try
            {
                SqlCommand command = StoreProcedureConnection("spLoginUser", connection);
                command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = loginData.UserName;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = PasswordEncryptDecrypt.EncodePasswordToBase64(loginData.Password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader[0];
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion Login

        /// <summary>
        ///  database connection with connection string
        /// </summary>
        private SqlConnection DatabaseConnection()
        {
            //connection string
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeData").Value;
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Generic method to use stored procedure
        /// </summary>
        /// <param name="storeProcedureName"></param>
        /// <param name="connection"></param>
        /// <returns> sql command </returns>
        #region StoreProcedureConnection
        public SqlCommand StoreProcedureConnection(string storeProcedureName, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(storeProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public int UpdateEmployeeDetails(UpdateModel data)
        {
            throw new NotImplementedException();
        }
        #endregion StoreProcedureConnection
    }
}
