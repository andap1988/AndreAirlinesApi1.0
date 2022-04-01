using AndreAirlinesApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEndpointFlight.File
{
    public class ReadJSON
    {
        public static List<Flight> LoadFlights(string arquivo)
        {
            Console.WriteLine("\n Lendo arquivo JSON...");
            List<Flight> flights = new();
            StreamReader reader = new(arquivo);
            string json = reader.ReadToEnd();

            flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            if (flights != null)
                return flights;
            return null;
        }
    }
}
