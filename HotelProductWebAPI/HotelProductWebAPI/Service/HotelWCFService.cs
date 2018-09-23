using HotelProductWebAPI.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HotelProductWebAPI.Service
{
    public class HotelWCFService
    {
        static HttpClient client = new HttpClient();


        public static async Task<List<Hotel>> GetHotelFromWCFAsync()
        {
            List<Hotel> hotels = null;
            HttpResponseMessage response = await client.GetAsync("http://localhost:52156/Services/HotelService.svc/Hotels");
            if (response.IsSuccessStatusCode)
            {
                hotels = await response.Content.ReadAsAsync<List<Hotel>>();
            }
            return hotels;
        }


        public static async Task<List<Hotel>> GetHotelFromJsonFileAsync()
        {
            List<Hotel> hotels = null;
            using (StreamReader reader = new StreamReader(@"C:\Users\ssrivastava\Desktop\HotelAPIUsignAsync\HotelProductWebAPI\HotelProductWebAPI\Repository\Hotels.json"))
            {
                var json = await reader.ReadToEndAsync();
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);

            }
            return hotels;
        }

        public static async Task<List<Room>> GetRoomsFromWCFAsync(int id)
        {
            List<Room> rooms = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("http://localhost:52156/Services/RoomService.svc/hotels/{0}/rooms", id));
            if (response.IsSuccessStatusCode)
            {
                rooms = await response.Content.ReadAsAsync<List<Room>>();
            }
            return rooms;
        }

        public static async Task<string> Book(int hotelid, string roomType, int numberOfRoomsToBeBooked)
        {
            string result  = null;
            HttpResponseMessage response = await client.PutAsync(string.Format("http://localhost:52156/Services/RoomService.svc/hotels/{0}/rooms/{1}/{2}", hotelid, roomType, numberOfRoomsToBeBooked), null);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<string>();
            }
            return result;
        }

    }
}