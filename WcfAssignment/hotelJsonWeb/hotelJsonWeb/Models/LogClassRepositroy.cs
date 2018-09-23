using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace hotelJsonWeb.Models
{
    public class LogRepository
    { 
        public void RegisterLog(Log log)
        {
            string connectionString = @"Data Source=TAVDESK154;Initial Catalog=HotelBooking;User Id=sa;Password=test123!@#";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Logger(Request, Response, Comment) VALUES(@request, @response, @comment)";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@request", log.Request);
            command.Parameters.AddWithValue("@response", log.Response);
            command.Parameters.AddWithValue("@comment", log.Comment);
            command.ExecuteNonQuery();
            connection.Close();
            
        }
    }
}