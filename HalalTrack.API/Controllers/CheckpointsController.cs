using HalalTrack.API.Data;
using HalalTrack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalalTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckpointsController : ControllerBase
    {
        private readonly HalalTrackDbContext _context;

        public CheckpointsController(HalalTrackDbContext context)
        {
            _context = context;
        }

        // POST: api/Checkpoints
        // Registra un nuevo paso en la cadena logística
        [HttpPost]
        public async Task<ActionResult<Checkpoint>> CreateCheckpoint(Checkpoint checkpoint)
        {
            // Validar que el lote existe
            var batchExists = await _context.Batches.AnyAsync(b => b.Id == checkpoint.BatchId);
            if (!batchExists)
            {
                return BadRequest("El lote (BatchId) especificado no existe.");
            }

            // Asegurarnos que la hora sea exacta si no viene en la petición
            if (checkpoint.Timestamp == default)
            {
                checkpoint.Timestamp = DateTime.UtcNow;
            }

            _context.Checkpoints.Add(checkpoint);
            await _context.SaveChangesAsync();

            return Ok(checkpoint);
        }
    }
}
