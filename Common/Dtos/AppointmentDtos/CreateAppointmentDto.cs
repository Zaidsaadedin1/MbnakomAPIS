namespace MbnakomAPIS.Common.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public string? UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string? PropertyType { get; set; }
        public string PreferredDate { get; set; } = string.Empty;
        public string PreferredTime { get; set; } = string.Empty;
        public string ProjectDetails { get; set; } = string.Empty;
        public bool TermsAccepted { get; set; }
    }
}
