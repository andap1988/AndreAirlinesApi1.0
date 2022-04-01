using InjectionEndpointFlight.http;
using System;

namespace InjectionEndpointFlight
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ROBO de Injestao de Dados");
            Console.WriteLine("\n ENDPOINT -> Voo");
            Console.WriteLine("\n Comecando...");

            Run.RunAsync().Wait();

            Console.WriteLine("\n Terminado o processo");
            Console.WriteLine("\n Pressione ENTER para finalizar");
            Console.ReadKey();
        }
    }
}
