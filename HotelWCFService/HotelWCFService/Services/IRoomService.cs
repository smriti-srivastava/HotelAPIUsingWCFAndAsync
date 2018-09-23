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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomService" in both code and config file together.
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        List<Room> GetRooms(string HotelId);
        [OperationContract]

        string Book(string hotelId, string roomType, string numberOfRoomsToBeBooked);
    }
}
