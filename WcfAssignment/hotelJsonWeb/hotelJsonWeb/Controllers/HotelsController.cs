using hotelJsonWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hotelJsonWeb.Controllers
{
    public class HotelsController : ApiController
    {
        List<HotelResponse> Hotels = new List<HotelResponse>();
        List<RoomEntity> Rooms = new List<RoomEntity>();
        [HttpGet]
        [Route("Hotel")]
        public async System.Threading.Tasks.Task<List<HotelResponse>> GetHotelAsync()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:60582/HotelService.svc/Hotel");
                List<HotelEntityWCF> content = new List<HotelEntityWCF>();
                if (response.StatusCode == HttpStatusCode.OK)

                {
                    content = await response.Content.ReadAsAsync<List<HotelEntityWCF>>();
                }

                string filepath = "c:/users/rnayyar/source/repos/hotelJsonWeb/hotelJsonWeb/hoteldata.json";
                string result = string.Empty;
                List<HotelEntityJson> HotelList = new List<HotelEntityJson>();
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    HotelList = JsonConvert.DeserializeObject<List<HotelEntityJson>>(json);

                }

                for (int i = 0; i < content.Count; i++)
                {
                    HotelResponse obj = new HotelResponse();
                    obj.id = content[i].id;
                    obj.hotelName = content[i].name;
                    obj.hotelAddress = content[i].address;
                    obj.HotelAmenities = HotelList[i].HotelAmenities;
                    obj.HotelContactNumber = HotelList[i].HotelContactNumber;
                    obj.HotelDescription = HotelList[i].HotelDescription;
                    obj.HotelPolicy = HotelList[i].HotelPolicy;
                    obj.HotelImageURL = HotelList[i].HotelImageURL;
                    Hotels.Add(obj);
                }
                UpdateLog("Put", "Success", "N/A");
            }
            catch(Exception e)
            {
                UpdateLog("Get", "Failed", e.StackTrace);
            }
         
               return Hotels;

            
        }

        private void UpdateLog(string req, string res, string ex)
        {
            Log log = new Log()
            {
                Request = req,
                Response = res,
                Comment = ex
            };
            LogSingleton.getSingletonInstance().logger(log);
        }

        [HttpGet]
        [Route("Hotel/{hotelId}")]
        public async System.Threading.Tasks.Task<List<RoomEntity>> GetRoomAsync([FromUri]int hotelId)
        {
            List<RoomEntity> content = new List<RoomEntity>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:60582/HotelService.svc/Hotel/" + hotelId);
                
                if (response.StatusCode == HttpStatusCode.OK)

                {
                    content = await response.Content.ReadAsAsync<List<RoomEntity>>();
                }
                UpdateLog("Put", "Success", "N/A");
            }
            catch(Exception e)
            {
                UpdateLog("Get", "Failed", e.StackTrace);
            }
                    return content;
        }

        [HttpPut]
        [Route("Hotel/{hotelid}/{roomType}/{noOfRooms}")]
        public async System.Threading.Tasks.Task<string> PutRoomAsync([FromUri]string hotelId, [FromUri]string roomType, [FromUri]string noOfRooms)
        {
            string content = "Error";
            try
            {
                var client = new HttpClient();
                var response = await client.PutAsync("http://localhost:60582/HotelService.svc/Hotel/" + hotelId + "/" + roomType + "/" + noOfRooms, null);        
                if (response.StatusCode == HttpStatusCode.OK)

                {
                    content = await response.Content.ReadAsAsync<string>();
                }
                UpdateLog("Put", "Success", "N/A");
            }
            catch(Exception e)
            {
                UpdateLog("Put", "Failed", e.StackTrace);
            }
            
            return content;
        }

    }
}
