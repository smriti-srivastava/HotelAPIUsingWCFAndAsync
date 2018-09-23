using HotelWCFService.Entities;
using Cassandra;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HotelWCFService.Repository
{
    public class HotelRepository
    {
        private Cluster cluster;
        private ISession session;
        private void Session()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("hoteldb");
        }
        public List<Hotel> GetAll()
        {
            Session();
            List<Hotel> hotels = new List<Hotel>();
            RowSet result = session.Execute("SELECT * FROM hotel");
            foreach (Row row in result)
            {
                hotels.Add(
                    new Hotel()
                    {
                        HotelId = Convert.ToInt32(row["hotelid"]),
                        Name = Convert.ToString(row["hotelname"]),
                        Address = Convert.ToString(row["hoteladdress"]),
                       
                    }
                );
            }
            return hotels;
        }

        public Hotel GetById(int id)
        {
            Session();
            Hotel hotel = null;
            RowSet result = session.Execute(string.Format("SELECT * FROM hotel where hotelid = {0}", id));
            foreach (Row row in result)
            {
                hotel = 
                    new Hotel()
                    {
                        HotelId = Convert.ToInt32(row["hotelid"]),
                        Name = Convert.ToString(row["hotelname"]),
                        Address = Convert.ToString(row["hoteladdress"]),

                    };
            }
            return hotel;
        }
    }
}