using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirlinesApi.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport AirportDestiny { get; set; }
        public Airport AirportOrigin { get; set; }
        public Airship Airship { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioEmbarque { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioDesembarque { get; set; }
        public Passenger Passenger { get; set; }
    }
}
