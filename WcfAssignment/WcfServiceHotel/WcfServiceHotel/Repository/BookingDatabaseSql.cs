using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceHotel
{
    public class BookingDatabaseSql : IsqlRepository
    {
        public void AddToBookingDatabase(Room room, Hotel hotel, int noOfRooms)
        {
            try
                {
                string connectionString = @"Data Source=TAVDESK154;Initial Catalog=HotelBooking;User ID=sa;Password=test123!@#";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "INSERT INTO BookingRecord (hotelid, roomtype, NoOfRoomsBooked, hotelName) VALUES(@hotelId, @roomtype, @numberofrooms, @hotelName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@hotelId", hotel.Id);
                command.Parameters.AddWithValue("@roomtype", room.Type);
                command.Parameters.AddWithValue("@numberofrooms", noOfRooms);
                command.Parameters.AddWithValue("@hotelName", hotel.Name);
                connection.Open();
                command.ExecuteNonQuery();
                
            }
                catch(Exception e)
                {
                     throw new Exception(e.StackTrace);
                }
            }
    }
}