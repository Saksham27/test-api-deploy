using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using EmpManagement.BL.Interface;
using EmpManagement.CL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmpManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory CachingProviderFactory;
        private IConfiguration configuration;
        IEmpManagementBL businessLayer;
        ResponseMessage response;


        public EmployeeController(IEasyCachingProvider cacheProvider , IEasyCachingProviderFactory cacheProviderFactory, IEmpManagementBL businessDI, IConfiguration config)
        {
            CachingProviderFactory = cacheProviderFactory;
            cachingProvider = this.CachingProviderFactory.GetCachingProvider("redis1");
            businessLayer = businessDI;
            configuration = config;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            try
            {
                response = businessLayer.GetAllEmployeeDetails();

                if (this.cachingProvider.Exists("AllEmployee"))
                {
                    var item = this.cachingProvider.Get<ResponseMessage>("AllEmployee");
                    return Ok(item);
                }
                else
                {
                    if (response.Status == true)
                    {
                        Console.WriteLine("true");
                        this.cachingProvider.Set<ResponseMessage>("AllEmployee", response, TimeSpan.FromMinutes(10));
                        var item = this.cachingProvider.Get<ResponseMessage>("AllEmployee");
                        return Ok(item);
                    }
                    else
                    {
                        return BadRequest(new { response.Status, response.Message });
                    }
                }
                
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpGet("data={inputData}")]
        public ActionResult GetEmployeeDetails(string inputData)
        {
            try
            {
                response = businessLayer.GetEmployeeDetails(inputData);
                if (response.Status == true)
                {
                    return Ok(new { response.Status, response.Message, response.Data });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployeeDetailsWithId(EmployeeId id)
        {
            try
            {
                response = businessLayer.GetEmployeeDetailsWithId(id);
                if (response.Status == true)
                {
                    return this.Ok(new { response.Status, response.Message, response.Data });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpPost]
        public ActionResult Register([FromBody] EmployeeModel model)
        {
            try
            {
                response = businessLayer.RegisterEmployee(model);
                if (response.Status == true)
                {
                    return this.Ok(new { response.Status, response.Message });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(EmployeeId id)
        {
            try
            {
                response = businessLayer.DeleteEmployee(id);
                if (response.Status == true)
                {
                    return this.Ok(new { response.Status, response.Message });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpPost("{login}")]
        public ActionResult Login(LoginModel loginData)
        {
            try
            {
                response = businessLayer.EmployeeLogin(loginData);
                if (response.Status == true)
                {
                    return this.Ok(new { response.Status, response.Message });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }

        [HttpPatch]
        public ActionResult Update(UpdateModel data)
        {
            try
            {
                response = businessLayer.UpdateEmployeeDetails(data);
                if (response.Status == true)
                {
                    return Ok(new { response.Status, response.Message });
                }
                else
                {
                    return BadRequest(new { response.Status, response.Message });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { error = exception.Message });
            }
        }


    }
}
