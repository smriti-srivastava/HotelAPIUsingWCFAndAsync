using HotelProductWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelProductWebAPI.Repository
{

    public class LogSQLRepository
    {
        private string connectionString = string.Empty;
        private SqlConnection connection;

        public LogSQLRepository()
        {
            this.connectionString = @"Data Source=TAVDESK149;Initial Catalog=LoggingDB;User Id=sa;Password=test123!@#";
        }

        private void Connection()
        {
            this.connection = new SqlConnection(this.connectionString);
        }
        public bool Create(Log log)
        {
            Connection();
            string query = "INSERT INTO Log(Request, Response, Comment) VALUES(@request, @response, @comment)";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@request", log.Request);
            command.Parameters.AddWithValue("@response", log.Response);
            command.Parameters.AddWithValue("@comment", log.Comment);
            connection.Open();
            return command.ExecuteNonQuery() > 0 ? true : false;
        }
    }
}