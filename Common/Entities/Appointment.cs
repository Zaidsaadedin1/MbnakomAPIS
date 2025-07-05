using MbnakomAPIS.Common.Enums;

namespace MbnakomAPIS.Common.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        // Client Information
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // Consultation Details
        public string ServiceType { get; set; } = null!;
        public string? PropertyType { get; set; } // Added for property type (apartment, villa, etc.)
        public DateTime PreferredDate { get; set; }
        public string PreferredTime { get; set; } = null!;
        public string ProjectDetails { get; set; } = null!; // Renamed from Concerns
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