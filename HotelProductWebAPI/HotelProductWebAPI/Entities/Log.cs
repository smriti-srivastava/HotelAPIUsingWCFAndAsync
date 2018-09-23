using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Entities
{
    public class Log
    {
        public string Request { get; set; }
        public string Response { get; set; }
        public string Comment { get; set; }
    }
}