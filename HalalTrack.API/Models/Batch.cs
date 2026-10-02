namespace HalalTrack.API.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public required string BatchNumber { get; set; }
        public required string ProductName { get; set; }
        public string? QrCodeUrl { get; set; }
        
        // Claves Foráneas
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        
        public int CertificateId { get; set; }
        public Certificate? Certificate { get; set; }
        
        // Relación: Un lote tiene un historial logístico (Checkpoints)
        public ICollection<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
    }
}
