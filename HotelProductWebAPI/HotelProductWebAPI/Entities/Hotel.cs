using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string HotelDescription { get; set; }
        public string HotelContactNumber { get; set; }
        public string HotelPolicy { get; set; }
        public List<string> HotelAmenities { get; set; }
        public List<string> HotelImageURL { get; set; }

    }
}