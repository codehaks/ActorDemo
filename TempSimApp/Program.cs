using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TempSimApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new HttpClient();

            for (int i = 1; i < 101; i++)
            {
                var temp = new Random().Next(20, 30);
                var payload = Newtonsoft.Json.JsonConvert
                    .SerializeObject(new SensorViewModel
                    {
                        SendorId = i,
                        Temprature = temp
                    });

                var content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");

                await client.PostAsync("https://localhost:5001/api/sensor", content);
            }
        }
    }
}
