using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Common.Dtos.AppointmentDtos
{
    public class GetAppointmentForAdminDto
    {
        public int Id { get; set; }

        // Appointment Info
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
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Related User Info
        public string? UserId { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
    }
}
