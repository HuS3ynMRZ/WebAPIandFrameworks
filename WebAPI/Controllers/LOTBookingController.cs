using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LOTBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public LOTBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(LOTbooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);
            if(result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var deletes = _context.Bookings.Find(id);
            if(deletes == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(deletes);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var allRecords = _context.Bookings.ToList();
            return new JsonResult(allRecords);
        }
    }
}
