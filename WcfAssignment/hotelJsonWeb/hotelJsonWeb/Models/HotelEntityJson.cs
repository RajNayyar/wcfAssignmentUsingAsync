﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotelJsonWeb.Models
{
    public class HotelEntityJson
    {
        public int HotelId { get; set; }
        public string HotelContactNumber { get; set; }
        public string HotelDescription { get; set; }
        public string HotelAmenities { get; set; }
        public string HotelPolicy { get; set; }
        public List<string> HotelImageURL { get; set; }
    }
}