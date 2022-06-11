using FlightManagementService.Model;
using FlightManagementService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace FlightManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public  class AirlineController : ControllerBase
    {

        private readonly IAirlineRepository _airlineRepository;
        public AirlineController(IAirlineRepository airlineDetail)
        {
            _airlineRepository = airlineDetail;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                var airline = _airlineRepository.GetAirlines();
                if (airline != null)
                {
                    return new OkObjectResult(airline);
                }
                throw new Exception("Failed to get all airlines");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new NotFoundObjectResult(response);
        }

        [Route("api/Airline1")]
        [HttpPost]
        public string Add([FromBody] AirlineDetails tbl)
        {
            return "nav";
        }

        //[HttpPost]
        //[Route("[Action]")]
        [Route("Home/Add")]
        [HttpPost]

        public IActionResult Register([FromBody] AirlineDetails tbl)
        {
            Response response = new Response();
            try
            {
                using (var scope = new TransactionScope())
                {
                    _airlineRepository.InsertAirline(tbl);
                    scope.Complete();
                    response.Message = "Successfully register airline";
                    response.Status = "Success";
                    response.StatusCode = StatusCodes.Status200OK.ToString();
                    //return Created("api/airline/", tbl);
                    return new OkObjectResult(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = "Failed to register airlines " + ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new NotFoundObjectResult(response);
        }


        [HttpDelete]
      
        [Route("Block")]
        //[Route("[Action]/{airlineNo}")]
        public IActionResult Block(int id)
        {
            Response response = new Response();
            try
            {
                _airlineRepository.DeleteAirline(id);
                response.Message = "Deleted Successfully";
                response.Status = "Success";
                response.StatusCode = StatusCodes.Status200OK.ToString();

            }
            catch (Exception ex)
            {
                response.Message = "Deletion failed " + ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new OkObjectResult(response);
        }
        [HttpGet]
        [Route("Add")]
        public string insertairline()
        {
            //response.Status = "Success";
            return "nav";
        }

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Airline1", "Airline2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
