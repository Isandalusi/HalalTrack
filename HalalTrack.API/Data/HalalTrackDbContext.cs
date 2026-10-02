using HalalTrack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HalalTrack.API.Data
{
    public class HalalTrackDbContext : DbContext
    {
        public HalalTrackDbContext(DbContextOptions<HalalTrackDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
    }
}
