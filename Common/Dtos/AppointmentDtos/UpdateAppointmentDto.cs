namespace MbnakomAPIS.Common.Dtos.OrderDtos
{
    public class UpdateAppointmentDto
    {
        public string? CompanyName { get; set; }
        public string ProjectType { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public decimal Budget { get; set; }
        public string Timeline { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public string? AdditionalRequirements { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }
}
