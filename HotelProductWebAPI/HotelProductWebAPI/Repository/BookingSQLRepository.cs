using HotelProductWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Repository
{
    public class BookingSQLRepository
    {
        private string connectionString = string.Empty;
        private SqlConnection connection;

        public BookingSQLRepository()
        {
            this.connectionString = @"Data Source=TAVDESK149;Initial Catalog=BookingDb;User Id=sa;Password=test123!@#";
        }

        private void Connection()
        {
            this.connection = new SqlConnection(this.connectionString);
        }

        public bool AddBooking(Booking booking)
        {
            Connection();
            string query = "INSERT INTO Booking(HotelId, RoomType, NumberOfRoomsBooked) VALUES(@hotelId, @roomType, @numberOfRoomsBooked)";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@hotelId", booking.HotelId);
            command.Parameters.AddWithValue("@roomType", booking.RoomType);
            command.Parameters.AddWithValue("@numberOfRoomsBooked", booking.NumberOfRoomsBooked);
            connection.Open();
            return command.ExecuteNonQuery() > 0 ? true : false;

        }
    }
}