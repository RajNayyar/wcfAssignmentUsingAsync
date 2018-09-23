using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceHotel
{
    interface IsqlRepository
    {
        void AddToBookingDatabase(Room room, Hotel hotel, int noOfRooms);
    }
}