using Newtonsoft.Json;

namespace AndreAirlinesApi.Model
{
    public class Address
    {
        #region Properties

        public int Id { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        public string Country { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }
        public int Number { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }

        public Address(string district, string city, string country, string cEP, string street, string state, int number, string complement)
        {
            District = district;
            City = city;
            Country = country;
            CEP = cEP;
            Street = street;
            State = state;
            Number = number;
            Complement = complement;
        }

        #endregion


    }
}
