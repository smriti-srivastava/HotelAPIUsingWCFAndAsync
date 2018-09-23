using HotelProductWebAPI.Entities;
using HotelProductWebAPI.Repository;
using HotelProductWebAPI.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelProductWebAPI.Controllers
{
    public class HotelController : ApiController
    {
       
        [HttpGet]
        [Route("hotels")]
        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> hotelsWCF = null;
            List<Hotel> hotelsJSON = null;
            try
            {
                Task<List<Hotel>> hotelsTaskWCF = HotelWCFService.GetHotelFromWCFAsync();
                Task<List<Hotel>> hotelsTaskJSON = HotelWCFService.GetHotelFromJsonFileAsync();
                hotelsWCF = await hotelsTaskWCF;
                hotelsJSON = await hotelsTaskJSON;
                foreach (Hotel hotel in hotelsWCF)
                {
                    Hotel hotelJson = hotelsJSON.Find(h => hotel.HotelId == h.HotelId);
                    if (hotelJson != null)
                    {
                        hotel.HotelAmenities = hotelJson.HotelAmenities;
                        hotel.HotelImageURL = hotelJson.HotelImageURL;
                        hotel.HotelDescription = hotelJson.HotelDescription;
                        hotel.HotelPolicy = hotelJson.HotelPolicy;
                    }
                }
                LogService.GetLogger().LogAction("Get: All Hotels", "Success", "List Of Hotels Returned");
            }
            catch(Exception exception)
            {
                LogService.GetLogger().LogAction("Get: All Hotels", "Failure" , exception.Message);
            }
            return hotelsWCF;
        }

        [HttpGet]
        [Route("hotels/{id}/rooms")]
        public async Task<List<Room>> GetRoomsFromWCFAsync([FromUri]int id)
        {
            List<Room> rooms = null;
            try
            {
                rooms = await HotelWCFService.GetRoomsFromWCFAsync(id);
                LogService.GetLogger().LogAction(String.Format("Get: Rooms for HotelId {0}", id), "Success", "List Of Rooms Returned");
            }
            catch (Exception exception)
            {
                LogService.GetLogger().LogAction(String.Format("Get: Rooms for HotelId {0}", id), "Failure", exception.Message);
            }
            return rooms;
        }

        [HttpPut]
        [Route("hotels/{hotelId}/rooms/{roomType}/{numberOfRoomsToBeBooked}")]
        public async Task<string> book([FromUri]int hotelId, [FromUri] string roomType, [FromUri] int numberOfRoomsToBeBooked)
        {
            string response = null;
            try
            {
                response = await HotelWCFService.Book(hotelId, roomType, numberOfRoomsToBeBooked);
                if (response.Equals("Success"))
                {
                    Booking booking = new Booking()
                    {
                        HotelId = hotelId,
                        RoomType = roomType,
                        NumberOfRoomsBooked = numberOfRoomsToBeBooked
                    };
                    BookingSQLRepository repository = new BookingSQLRepository();
                    repository.AddBooking(booking);
                    LogService.GetLogger().LogAction("Put: Book", "Success", "Room Booked" );
                }
            }
            catch(Exception exception)
            {
                LogService.GetLogger().LogAction("Put: Book", "Failure", exception.Message);
            }
            return response;
        }
    }
}
