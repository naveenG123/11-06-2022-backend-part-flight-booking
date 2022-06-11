using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementservice.Model;
using UserManagementservice.Repository;

namespace UserManagementservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository repos)
        {
            this._loginRepository = repos;
        }

        #region Public Methods

        [HttpGet]
        public ActionResult Get([FromQuery] string userName, [FromQuery] string pwd)
        {
            try
            {
                bool authentication = _loginRepository.AuthenticateUser(userName, pwd);
                if (authentication)
                {
                    return Ok(GenerateResponseData(true, null, "Login Success !!"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, GenerateResponseData(false, null, "Invalid Username or Password !!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }
        [Route("Addnewuser")]
        [HttpPost]
        public ActionResult Post([FromBody] userlogin obj)
        {
            try
            {
                bool userNameExists = _loginRepository.IsUserNameExists(obj.UserName);
                if (userNameExists)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, GenerateResponseData(false, null, "Username already exists !!"));
                }
                else
                {
                    _loginRepository.AddNewUser(obj);
                    return StatusCode(StatusCodes.Status201Created);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _loginRepository.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }
        }

        #endregion

        #region Private Methods

        private object GenerateResponseData(bool isSuccess, object data, string message)
        {
            return new { isSuccess, data, message };
        }

        #endregion
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
