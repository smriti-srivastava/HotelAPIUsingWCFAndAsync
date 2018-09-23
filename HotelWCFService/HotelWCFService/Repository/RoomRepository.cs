using Cassandra;
using HotelWCFService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWCFService.Repository
{
    public class RoomRepository
    {
        private Cluster cluster;
        private ISession session;
        private void Session()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("hoteldb");
        }
        public List<Room> GetRoomsByHotelId(int hotelId)
        {
            Session();
            List<Room> rooms = new List<Room>();
            RowSet result = session.Execute(string.Format("SELECT * FROM room where hotelId = {0} ALLOW FILTERING", hotelId));
            foreach (Row row in result)
            {
                rooms.Add(
                    new Room()
                    {
                       RoomType = Convert.ToString(row["roomtype"]),
                       Rate = Convert.ToDouble(row["rate"]),
                       Availability = Convert.ToInt32(row["availability"]),
                       Total = Convert.ToInt32(row["total"]),
                       HotelId = Convert.ToInt32(row["hotelid"])
                    }
                );
            }
            return rooms;
        }

        public Room GetRoomsByTypeAndHotel(int hotelId, string roomType)
        {
            Session();
            Room room = new Room();
            RowSet result = session.Execute(string.Format("SELECT * FROM room where hotelid = {0} AND roomtype= '{1}' ALLOW FILTERING", hotelId, roomType));
            foreach (Row row in result)
            {
                room = 
                    new Room()
                    {
                        RoomType = Convert.ToString(row["roomtype"]),
                        Rate = Convert.ToDouble(row["rate"]),
                        Availability = Convert.ToInt32(row["availability"]),
                        Total = Convert.ToInt32(row["total"]),
                        HotelId = Convert.ToInt32(row["hotelid"])
                    }
                ;
            }
            return room;
        }

        public bool UpdateRoomAvailability(Room room)
        {
            Session();
            RowSet result = session.Execute(string.Format("Update room set availability = {0} where hotelid = {1} AND roomtype = '{2}' ", room.Availability, room.HotelId, room.RoomType));
            if (result != null) return true;
            return false;
        }
    }
}