namespace IndiaTalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; } //connection with difficulty whether it is a normal, medium or difficult
        public Guid RegionId { get; set; }  //connection with Region

        // Navigation Properties

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }
    }
}
