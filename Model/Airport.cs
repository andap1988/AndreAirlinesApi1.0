using System.ComponentModel.DataAnnotations;

namespace AndreAirlinesApi.Model
{
    public class Airport
    {
        [Key]
        public string Acronym { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
    }
}
