namespace CarApp1.Pages.Models
{
    public class EditCarModel
    {
        public Guid Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public string? EngineType { get; set; }
        public string? EngineSize { get; set; }
        public string? ImagePath { get; set; }
    }
}
