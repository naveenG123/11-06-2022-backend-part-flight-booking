using InventoryManagement.Model;
using InventoryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository repository)
        {
            _inventoryRepository = repository;
        }


        [Route("getinventory")]
        [HttpGet]

        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                var airline = _inventoryRepository.GetInventory();
                if (airline == null)
                    throw new Exception("No flight exists");
                else
                    return new OkObjectResult(airline);
            }
            catch (Exception ex)
            {
                if (String.Equals(ex.Message, "No Inventory exists", StringComparison.OrdinalIgnoreCase) || String.Equals(ex.Message, "No flight exists", StringComparison.OrdinalIgnoreCase))
                {
                    response.Message = ex.Message;
                    response.Status = "Success";
                    response.StatusCode = StatusCodes.Status200OK.ToString();
                    return new OkObjectResult(ex.Message);
                }
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new NotFoundObjectResult(response);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Register([FromBody] InventoryDetails tbl)
        {
            Response response = new Response();
            try
            {
               
                {
                    _inventoryRepository.AddInventory(tbl);
                    
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

        [HttpPost]
        [Route("Addinventorydetails")]
        public IActionResult Add([FromBody] InventoryDetails tbl)
        {
            Response response = new Response();
            try
            {
                
                    _inventoryRepository.AddInventory(tbl);
                   
                    response.Message = "Successfully add inevntory ";
                    response.Status = "Success";
                    response.StatusCode = StatusCodes.Status200OK.ToString();
                    return new OkObjectResult(response);
                
            }
            catch (Exception ex)
            {
                response.Message = "Failed to add " + ex.Message;
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
                _inventoryRepository.DeleteInventory(id);
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
        [Route("get")]
        [HttpGet]
        public IActionResult Get(string fromplace, string toplace)
        {
            Response response = new Response();
            try
            {
                var flights = _inventoryRepository.GetAllFlightBasedUponPlaces(fromplace, toplace);
                if (flights.Count() != 0)
                    return new OkObjectResult(flights);
                else
                    throw new Exception("No flight exists");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new NotFoundObjectResult(Response);
        }
        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Inventory1", "Inventory2" };
        //}

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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
