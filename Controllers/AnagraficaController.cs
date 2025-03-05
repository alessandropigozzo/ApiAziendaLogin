using ApiAziendaLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiAziendaLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficheController : ControllerBase
    {
        private readonly LoginDbContext _context;
        private readonly ILogger<AnagraficheController> _logger;

        public AnagraficheController(LoginDbContext context, ILogger<AnagraficheController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Anagrafiche
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anagrafiche>>> GetAnagrafiche()
        {
            var anagrafiche = await _context.Anagrafiche.ToListAsync();
            return Ok(anagrafiche);
        }

        // GET: api/Anagrafiche/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anagrafiche>> GetAnagrafica(int id)
        {
            var anagrafica = await _context.Anagrafiche
                                           .Include(a => a.Utenti) // Includi la relazione con Utenti
                                           .FirstOrDefaultAsync(a => a.IdAnagrafica == id);

            if (anagrafica == null)
            {
                _logger.LogWarning($"Anagrafica con ID {id} non trovata.");
                return NotFound();
            }

            return Ok(anagrafica);
        }

        // POST: api/Anagrafiche
        [HttpPost]
        public async Task<ActionResult<Anagrafiche>> CreateAnagrafica(Anagrafiche anagrafica)
        {
            if (anagrafica == null)
            {
                _logger.LogWarning("La richiesta è vuota.");
                return BadRequest("Anagrafica non valida.");
            }

            _context.Anagrafiche.Add(anagrafica);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnagrafica), new { id = anagrafica.IdAnagrafica }, anagrafica);
        }

        // PUT: api/Anagrafiche/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnagrafica(int id, Anagrafiche anagrafica)
        {
            if (id != anagrafica.IdAnagrafica)
            {
                _logger.LogWarning($"ID della risorsa non corrisponde a quello dell'entità.");
                return BadRequest();
            }

            _context.Entry(anagrafica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnagraficaExists(id))
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

        // DELETE: api/Anagrafiche/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnagrafica(int id)
        {
            var anagrafica = await _context.Anagrafiche.FindAsync(id);
            if (anagrafica == null)
            {
                _logger.LogWarning($"Anagrafica con ID {id} non trovata.");
                return NotFound();
            }

            _context.Anagrafiche.Remove(anagrafica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnagraficaExists(int id)
        {
            return _context.Anagrafiche.Any(e => e.IdAnagrafica == id);
        }
    }
}
