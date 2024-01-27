using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Taco_Food_Truck.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Taco_Food_Truck.Models;


    
        [Route("api/[controller]")]
        [ApiController]
        public class TacosController : ControllerBase
        {
            private readonly TacoDbContext _context;

            public TacosController(TacoDbContext context)
            {
                _context = context;
            }

            // GET: api/Tacos
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Taco>>> GetTacos([FromQuery] bool? softShell)
            {
                IQueryable<Taco> tacosQuery = _context.Tacos;

                if (softShell.HasValue)
                {
                    tacosQuery = tacosQuery.Where(t => t.SoftShell == softShell);
                }

                var tacos = await tacosQuery.ToListAsync();
                return Ok(tacos);
            }

            // GET: api/Tacos/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Taco>> GetTaco(int id)
            {
                var taco = await _context.Tacos.FindAsync(id);

                if (taco == null)
                {
                    return NotFound();
                }

                return Ok(taco);
            }



            // POST: api/Tacos
            [HttpPost]
            public async Task<ActionResult<Taco>> CreateTaco([FromBody] Taco taco)
            {
                if (taco == null)
                {
                    return BadRequest("Taco object is null");
                }

                _context.Tacos.Add(taco);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTaco), new { id = taco.Id }, taco);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaco(int id)
        {
            var taco = await _context.Tacos.FindAsync(id);

            if (taco == null)
            {
                return NotFound();
            }

            _context.Tacos.Remove(taco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    }

   
