namespace HalalTrack.API.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public required string Issuer { get; set; }
        public DateTime ValidUntil { get; set; }
        public string? DocumentUrl { get; set; }
        
        // Relación: Un certificado puede amparar múltiples lotes
        public ICollection<Batch> Batches { get; set; } = new List<Batch>();
    }
}
