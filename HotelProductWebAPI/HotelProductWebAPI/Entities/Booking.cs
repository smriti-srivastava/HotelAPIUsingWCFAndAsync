using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Entities
{
    public class Booking
    {
        public int HotelId { get; set; }
        public int NumberOfRoomsBooked { get; set; }
        public string RoomType { get; set; }
    }
}