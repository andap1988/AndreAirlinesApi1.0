using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesApi.Model;

namespace AndreAirlinesApi.Data
{
    public class AndreAirlinesApiContext : DbContext
    {
        public AndreAirlinesApiContext (DbContextOptions<AndreAirlinesApiContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirlinesApi.Model.Passenger> Passenger { get; set; }

        public DbSet<AndreAirlinesApi.Model.Address> Address { get; set; }

        public DbSet<AndreAirlinesApi.Model.Airport> Airport { get; set; }

        public DbSet<AndreAirlinesApi.Model.Airship> Airship { get; set; }

        public DbSet<AndreAirlinesApi.Model.Flight> Flight { get; set; }
    }
}
