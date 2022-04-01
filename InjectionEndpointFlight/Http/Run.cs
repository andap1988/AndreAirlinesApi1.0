using AndreAirlinesApi.Model;
using InjectionEndpointFlight.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEndpointFlight.http
{
    public class Run
    {

        public static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44382/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<Flight> flights = ReadJSON.LoadFlights(@"C:\Users\Anderson\source\repos\InjectionEndpointFlight\File\data.json");

                Console.WriteLine("\n Fim da leitura do JSON");
                foreach (Flight flight in flights)
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Flights", flight);
                }
                Console.WriteLine("\n Fim da inserção");
            }
        }
    }
}
