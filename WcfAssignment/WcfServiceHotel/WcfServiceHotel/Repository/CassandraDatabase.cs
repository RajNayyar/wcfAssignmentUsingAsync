using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceHotel
{
    public class CassandraDatabase : IRepository
    {
        public List<Hotel> GetAllHotels()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotelbooking");
            List<Hotel> hotels = new List<Hotel>();
            //Prepare a statement once
            RowSet result = session.Execute("SELECT * FROM hotel");
            foreach (Row row in result)
            {
                hotels.Add(
                    new Hotel()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Name = Convert.ToString(row["name"]),
                        Address = Convert.ToString(row["address"]),

                    }
                );
            }
            return hotels;
        }

        
        public List<Room> GetAllRooms(string hotelId)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotelbooking");
            List<Room> rooms = new List<Room>();
            //Prepare a statement once
            RowSet result = session.Execute("SELECT * FROM rooms where hotelid = "+hotelId+" ALLOW FILTERING");  //changes might be required
            foreach (Row row in result)
            {
                rooms.Add(
                    new Room()
                    {
                        Type = Convert.ToString(row["type"]),
                        HotelId = Convert.ToInt32(row["hotelid"]),
                        Availability = Convert.ToInt32(row["availability"])
                    }
                );
            }
            return rooms;
        }

        public Hotel GetHotelById(string hotelId)
        {

            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotelbooking");
            List<Hotel> hotels = new List<Hotel>();
            //Prepare a statement once
            RowSet result = session.Execute("SELECT * FROM hotel where id = "+ hotelId);
            foreach (Row row in result)
            {
                hotels.Add(
                    new Hotel()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Name = Convert.ToString(row["name"]),
                        Address = Convert.ToString(row["address"]),
                    }
                );
            }
            return hotels[0];
        }

        public Room GetRoomsByTypeAndHotel(string hotelId, string roomType)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotelbooking");
            Room room = new Room();
            //Prepare a statement once
            RowSet result = session.Execute("SELECT * FROM rooms where hotelid = " + hotelId + " and type = '"+ roomType +"' ALLOW FILTERING");  //changes might be required
            foreach (Row row in result)
            {
                room = 
                    new Room()
                    {
                        Type = Convert.ToString(row["type"]),
                        HotelId = Convert.ToInt32(row["hotelid"]),
                        Availability = Convert.ToInt32(row["availability"])

                    }
                ;
            }
            return room;
        }

        public void UpdateRoom(Room room)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotelbooking");
            RowSet result = session.Execute(string.Format("Update rooms set availability = {0} where hotelid = {1} AND type = '{2}' ", room.Availability, room.HotelId, room.Type));
        }
    }
}