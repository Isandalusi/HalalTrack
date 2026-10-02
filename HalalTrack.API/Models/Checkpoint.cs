namespace HalalTrack.API.Models
{
    public class Checkpoint
    {
        public int Id { get; set; }
        public required string Status { get; set; } // Origin, InTransit, Arrived, Delivered
        public required string Location { get; set; }
        public string? TransportId { get; set; } // Flight / Container number
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        // Claves Foráneas
        public int BatchId { get; set; }
        public Batch? Batch { get; set; }
    }
}
