using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceHotel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
 
        [WebGet(UriTemplate = "/Hotel", ResponseFormat = WebMessageFormat.Json)]
        public List<Hotel> GetHotelList()
        {
            IRepository data = new CassandraDatabase();
            return data.GetAllHotels();
        }

        [WebGet(UriTemplate = "/Hotel/{hotelid}", ResponseFormat = WebMessageFormat.Json)]
        public List<Room> GetRoomList(string hotelId)
        {
            IRepository data = new CassandraDatabase();
            return data.GetAllRooms((hotelId));
        }

        [WebInvoke(Method = "PUT", UriTemplate = "/Hotel/{hotelid}/{roomType}/{noOfRooms}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Book(string hotelId, string roomType, string noOfRooms)
        {
            IRepository repository = new CassandraDatabase();
            Room room = repository.GetRoomsByTypeAndHotel(hotelId, roomType);
            Hotel hotel = repository.GetHotelById(hotelId);
            if (room == null) return "Invalid RoomType Or Hotel";
            if (room.Availability >= int.Parse(noOfRooms))
            {
                room.Availability -= int.Parse(noOfRooms);
                repository.UpdateRoom(room);
                IsqlRepository sqlRepo = new BookingDatabaseSql();
                sqlRepo.AddToBookingDatabase(room, hotel, int.Parse(noOfRooms));
                return "Success";
            }
            return "Not Available";
        }
    }
}
