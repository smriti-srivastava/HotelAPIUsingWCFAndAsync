using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HotelWCFService.Entities;
using HotelWCFService.Repository;

namespace HotelWCFService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        [WebGet(UriTemplate = "/Hotel/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Hotel GetHotel(string id)
        {
            HotelRepository repository = new HotelRepository();
            Hotel hotel = repository.GetById(int.Parse(id));
            return hotel;
        }

        [WebGet(UriTemplate = "/Hotels", ResponseFormat = WebMessageFormat.Json)]
        public List<Hotel> GetHotels()
        {
            HotelRepository repository = new HotelRepository();
            List<Hotel> hotels = repository.GetAll();
            return hotels;
        }
    }
}
