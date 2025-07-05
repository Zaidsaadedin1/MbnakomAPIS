using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Common.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        // Patient Information
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // Appointment Details
        public string ServiceType { get; set; } = null!;
        public DateTime PreferredDate { get; set; }
        public string PreferredTime { get; set; } = null!;
        public string Concerns { get; set; } = null!;
        public string? MedicalHistory { get; set; }

        public bool TermsAccepted { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        // Relationship to User
        public string? UserId { get; set; }
        public User? User { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
