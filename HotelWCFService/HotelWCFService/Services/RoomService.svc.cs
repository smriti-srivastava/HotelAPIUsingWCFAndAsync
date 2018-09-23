using HotelWCFService.Entities;
using HotelWCFService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelWCFService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomService.svc or RoomService.svc.cs at the Solution Explorer and start debugging.
    public class RoomService : IRoomService
    {
        [WebGet(UriTemplate = "/hotels/{hotelid}/rooms", ResponseFormat = WebMessageFormat.Json)]
        public List<Room> GetRooms(string hotelId)
        {
            RoomRepository repository = new RoomRepository();
            List<Room> rooms = repository.GetRoomsByHotelId(int.Parse(hotelId));
            return rooms;
        }

        [WebInvoke(Method = "PUT", UriTemplate = "/hotels/{hotelid}/rooms/{roomType}/{numberOfRoomsToBeBooked}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Book(string hotelId, string roomType, string numberOfRoomsToBeBooked)
        {
            RoomRepository repository = new RoomRepository();
            Room room = repository.GetRoomsByTypeAndHotel(int.Parse(hotelId), roomType);
            if (room == null) return "Invalid RoomType Or Hotel";
            if (room.Availability > int.Parse(numberOfRoomsToBeBooked))
            {
                room.Availability -= int.Parse(numberOfRoomsToBeBooked);
                repository.UpdateRoomAvailability(room);
                return "Success";
            }
            return "Not Available";
        }
    }
}
