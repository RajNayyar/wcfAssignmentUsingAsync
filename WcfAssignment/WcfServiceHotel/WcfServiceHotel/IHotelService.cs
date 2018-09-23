using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceHotel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelService" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        List<Hotel> GetHotelList();
        [OperationContract]
        List<Room> GetRoomList(string hotelId);
        [OperationContract]
        string Book(string hotelId, string roomType, string noOfRooms);
    }
}
