using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesApi.Data;
using AndreAirlinesApi.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AndreAirlinesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreAirlinesApiContext _context;

        public AddressesController(AndreAirlinesApiContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            /* Teste de inserção direta no post do novo address. Atualmente so esta sendo feita pelo controller do passenger
            var newAddress = address;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"{address.CEP}/json");

                    if (response.IsSuccessStatusCode)
                    {
                        var addressResponse = await response.Content.ReadAsStringAsync();

                        newAddress = JsonConvert.DeserializeObject<Address>(addressResponse);
                        newAddress.Country = "Brasil";
                        newAddress.Number = address.Number;

                        _context.Address.Add(newAddress);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n Exception Caught!");
                Console.WriteLine(" Message: " + e.Message);
            }*/

            _context.Address.Add(newAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = newAddress.Id }, newAddress);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
