using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddRestaurantAPI.Models;

namespace AddRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRestaurantsController : ControllerBase
    {
        private readonly AddRestaurantDbContext _context;

        public AddRestaurantsController(AddRestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/AddRestaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddRestaurant>>> GetAddRestaurant()
        {
            return await _context.AddRestaurant.ToListAsync();
        }

        // GET: api/AddRestaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddRestaurant>> GetAddRestaurant(int id)
        {
            var addRestaurant = await _context.AddRestaurant.FindAsync(id);

            if (addRestaurant == null)
            {
                return NotFound();
            }

            return addRestaurant;
        }

        // PUT: api/AddRestaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddRestaurant(int id, AddRestaurant addRestaurant)
        {
            if (id != addRestaurant.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(addRestaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddRestaurantExists(id))
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

        // POST: api/AddRestaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddRestaurant>> PostAddRestaurant(AddRestaurant addRestaurant)
        {
            _context.AddRestaurant.Add(addRestaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddRestaurant", new { id = addRestaurant.RestaurantId }, addRestaurant);
        }

        // DELETE: api/AddRestaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddRestaurant(int id)
        {
            var addRestaurant = await _context.AddRestaurant.FindAsync(id);
            if (addRestaurant == null)
            {
                return NotFound();
            }

            _context.AddRestaurant.Remove(addRestaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddRestaurantExists(int id)
        {
            return _context.AddRestaurant.Any(e => e.RestaurantId == id);
        }
    }
}
