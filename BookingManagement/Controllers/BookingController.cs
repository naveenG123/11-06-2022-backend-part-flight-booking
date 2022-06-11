using BookingManagement.Model;
using BookingManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _repository;
        //private ITopicProducer<BookflightTblUsr> _topicProducer;

    
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
            //_topicProducer = topic;

        }

        [HttpGet]
        [Route("GetAllBooking")]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                var allBookings = _repository.GetBookingDetail();
                if (allBookings != null)
                    return new OkObjectResult(allBookings);
                else
                    throw new Exception("No record found");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status404NotFound.ToString();
            }
            return new NotFoundObjectResult(response);

        }
        [HttpPost]
        [Route("add")]
        public IActionResult Register([FromBody] BookflightTbl tbl)
        {
            Response response = new Response();
            try
            {
                using (var scope = new TransactionScope())
                {
                    _repository.AddBookingDetail(tbl);
                    scope.Complete();
                    response.Message = "Successfully Added Booking Details";
                    response.Status = "Success";
                    response.StatusCode = StatusCodes.Status200OK.ToString();
                    //return Created("api/airline/", tbl);
                    return new OkObjectResult(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = "Failed to Add Booking Details " + ex.Message;
                response.Status = "Error";
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
            }
            return new NotFoundObjectResult(response);
        }
        
        //public IActionResult Post([FromBody] BookflightTblUsr bookflight)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        {
        //            var res = _repository.AddBookingDetail(bookflight);
        //            response.Message = res;
        //            response.StatusCode = StatusCodes.Status200OK.ToString();
        //            response.Status = "Success";
        //            return new OkObjectResult(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //        response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
        //        response.Status = "Error";
        //    }
        //    return new NotFoundObjectResult(response);
        //}

        /// <summary>
        /// Get history based upon user's emailid
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Action/emailId")]
        public IActionResult History(string emailId)
        {
            Response response = new Response();
            try
            {
                var history = _repository.GetUserHistory(emailId);
                if (history != null)
                    return new OkObjectResult(history);
                else
                    throw new Exception("No history found");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError.ToString();
                response.Status = "Error";
            }
            return new NotFoundObjectResult(response);
        }


        /// <summary>
        /// Cancel booking based upon pnr
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("cancellingbooking")]
        public void Bookingcancel(int id)
        {
            Response response = new Response();
            try
            {
                _repository.CancelBooking(id);
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
        }
           
            
   
        /// <summary>
        /// Get Ticket detail based upon pnr
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Action/pnr")]
        public IActionResult Ticket(string pnr)
        {
            Response response = new Response();
            try
            {
                var result = _repository.GetBookingDetailFromPNR(pnr);
                if (result != null)
                {
                    return new OkObjectResult(result);
                }
                else
                    throw new Exception("Failed to get ticket based upon PNR " + pnr);
            }
            catch (Exception ex) { response.Message = ex.Message; response.StatusCode = StatusCodes.Status500InternalServerError.ToString(); response.Status = "Error"; }
            return new NotFoundObjectResult(response);
        }
        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Booking1", "Booking2" };
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
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
