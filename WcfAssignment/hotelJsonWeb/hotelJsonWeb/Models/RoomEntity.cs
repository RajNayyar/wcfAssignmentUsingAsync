using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelJsonWeb.Models
{
    public class RoomEntity
    {
        public int id { set; get; }
        public int hotelid { set; get; }
        public int availability { set; get; }
        public string type { set; get; }
    }
}