using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Taco_Food_Truck.Models;

    namespace Taco_Food_Truck.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DrinksController : ControllerBase
        {
            private readonly TacoDbContext _context;

            public DrinksController(TacoDbContext context)
            {
                _context = context;
            }

            // GET: api/Drinks
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks([FromQuery] string sortByCost)
            {
                IQueryable<Drink> drinksQuery = _context.Drinks;

                if (!string.IsNullOrWhiteSpace(sortByCost))
                {
                    if (sortByCost.ToLower() == "ascending")
                    {
                        drinksQuery = drinksQuery.OrderBy(d => d.Cost);
                    }
                    else if (sortByCost.ToLower() == "descending")
                    {
                        drinksQuery = drinksQuery.OrderByDescending(d => d.Cost);
                    }
                }

                var drinks = await drinksQuery.ToListAsync();
                return Ok(drinks);
            }
        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrink(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);

            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }
        [HttpPost]
        public async Task<ActionResult<Drink>> CreateDrink([FromBody] Drink drink)
        {
            if (drink == null)
            {
                return BadRequest("Drink object is null");
            }

            _context.Drinks.Add(drink);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrink), new { id = drink.Id }, drink);
        }

        // PUT: api/Drinks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrink(int id, [FromBody] Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest("ID mismatch between URL and body");
            }

            _context.Entry(drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
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

        private bool DrinkExists(int id)
        {
            return _context.Drinks.Any(e => e.Id == id);
        }
    }
}

   
