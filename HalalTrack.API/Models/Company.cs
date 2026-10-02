namespace HalalTrack.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; } // Supplier, Logistics, Restaurant
        
        // Relación: Una compañía puede ser dueña de varios lotes
        public ICollection<Batch> Batches { get; set; } = new List<Batch>();
    }
}
