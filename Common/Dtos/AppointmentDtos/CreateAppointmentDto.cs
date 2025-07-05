namespace MbnakomAPIS.Common.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string ServiceType { get; set; } = null!;
        public DateTime PreferredDate { get; set; }
        public string PreferredTime { get; set; } = null!;
        public string Concerns { get; set; } = null!;
        public string? MedicalHistory { get; set; }

        public bool TermsAccepted { get; set; }
        public string? UserId { get; set; }
    }
}
