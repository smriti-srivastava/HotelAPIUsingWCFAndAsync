using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWCFService.Entities
{
    public class Room
    {
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int Availability { get; set; }
        public int Total { get; set; }
        public double Rate {get;set;} 
    }
}