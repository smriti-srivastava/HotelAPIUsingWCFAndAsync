using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWCFService.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}