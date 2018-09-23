using HotelWCFService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelWCFService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelService" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {

        [OperationContract]
        List<Hotel> GetHotels();

        [OperationContract]
        Hotel GetHotel(string id);
    }
}
