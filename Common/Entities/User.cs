using MbnakomAPIS.Controllers;
using Microsoft.AspNetCore.Identity;

namespace MbnakomAPIS.Common.Entities
{
    public class User : IdentityUser
    {
        // Personal Info
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;

        // Contact & Profile
        public string? Bio { get; set; }
        public string? Occupation { get; set; }
        public string? Location { get; set; }

        // Interests (Consider JSON serialization or separate table)
        public List<string> Interests { get; set; } = new();

        // OTP Verification
        public string? Otp { get; set; }
        public DateTime? OtpExpiresAt { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
