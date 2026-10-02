using HalalTrack.API.Data;
using HalalTrack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalalTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly HalalTrackDbContext _context;

        public BatchesController(HalalTrackDbContext context)
        {
            _context = context;
        }

        // POST: api/Batches
        [HttpPost]
        public async Task<ActionResult<Batch>> CreateBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBatch), new { id = batch.Id }, batch);
        }

        // GET: api/Batches/{id}
        // Este endpoint devuelve el lote, la empresa, el certificado y la línea de tiempo (Checkpoints)
        [HttpGet("{id}")]
        public async Task<ActionResult<Batch>> GetBatch(int id)
        {
            var batch = await _context.Batches
                .Include(b => b.Company)
                .Include(b => b.Certificate)
                .Include(b => b.Checkpoints.OrderBy(c => c.Timestamp))
                .FirstOrDefaultAsync(b => b.Id == id);

            if (batch == null)
            {
                return NotFound();
            }

            return batch;
        }

        // GET: api/Batches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batch>>> GetAllBatches()
        {
            return await _context.Batches.ToListAsync();
        }
    }
}
