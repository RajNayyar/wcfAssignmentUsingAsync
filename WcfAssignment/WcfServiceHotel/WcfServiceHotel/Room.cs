using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceHotel
{
    public class Room
    {
        public int HotelId { get; set; }
        public int Availability { get; set; }
        public string Type { get; set; }
    }
}