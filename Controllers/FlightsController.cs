using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesApi.Data;
using AndreAirlinesApi.Model;

namespace AndreAirlinesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AndreAirlinesApiContext _context;

        public FlightsController(AndreAirlinesApiContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlight()
        {
            return await _context.Flight.Include(f => f.AirportDestiny.Address)
                                        .Include(f => f.AirportOrigin.Address)
                                        .Include(f => f.Airship)
                                        .Include(f => f.Passenger.Address)
                                        .ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            var airportDestiny = await _context.Airport.Include(a => a.Address).Where(a => a.Acronym == flight.AirportDestiny.Acronym).FirstOrDefaultAsync();
            var airportOrigin = await _context.Airport.Include(a => a.Address).Where(a => a.Acronym == flight.AirportOrigin.Acronym).FirstOrDefaultAsync();
            var airship = await _context.Airship.FindAsync(flight.Airship.Id);
            var passengerSearch = await _context.Passenger.Include(p => p.Address).Where(p => p.Cpf == flight.Passenger.Cpf).FirstOrDefaultAsync();

            //var passenger = await _context.Passenger.Include(p => p.Address).Where(d => d.Id == flight.Passenger.Address.Id).FirstOrDefaultAsync();

            if (airportDestiny != null)
                flight.AirportDestiny = airportDestiny;
            if (airportOrigin != null)
                flight.AirportOrigin = airportOrigin;
            if (airship != null)
                flight.Airship = airship;
            if (passengerSearch != null)
                flight.Passenger = passengerSearch;

            _context.Flight.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);

            /*_context.Flight.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);*/
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.Id == id);
        }
    }
}
