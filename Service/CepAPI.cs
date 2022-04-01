using AndreAirlinesApi.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AndreAirlinesApi.Service
{
    public class CepAPI
    {
        public static async Task<Address> JsonViaCEPAsync(string cep)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var end = JsonConvert.DeserializeObject<Address>(responseBody);
                    return end;
                }
            }
            catch (HttpRequestException exception)
            {
                throw exception;
            }
        }
    }
}
