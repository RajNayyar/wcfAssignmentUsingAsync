using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceHotel
{
    public interface IRepository
    {
        List<Hotel> GetAllHotels();
        List<Room> GetAllRooms(string hotelId);
        Room GetRoomsByTypeAndHotel(string hotelId, string roomType);
        Hotel GetHotelById(string hotelId);
        void UpdateRoom(Room room);
    }
}