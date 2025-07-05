namespace MbnakomAPIS.Common.Dtos.UserDto
{
    public class GetUserDto
    {
        public string Id { get; set; } = null!;                         // From IdentityUser
        public string UserName { get; set; } = null!;                   // From IdentityUser
        public string NormalizedUserName { get; set; } = null!;         // From IdentityUser
        public string Email { get; set; } = null!;                      // From IdentityUser
        public string NormalizedEmail { get; set; } = null!;            // From IdentityUser
        public bool EmailConfirmed { get; set; }                        // From IdentityUser
        public string PasswordHash { get; set; } = null!;               // From IdentityUser (optional to return)
        public string SecurityStamp { get; set; } = null!;              // From IdentityUser
        public string ConcurrencyStamp { get; set; } = null!;           // From IdentityUser
        public string PhoneNumber { get; set; } = null!;                // From IdentityUser
        public bool PhoneNumberConfirmed { get; set; }                  // From IdentityUser
        public bool TwoFactorEnabled { get; set; }                      // From IdentityUser
        public DateTimeOffset? LockoutEnd { get; set; }                 // From IdentityUser
        public bool LockoutEnabled { get; set; }                        // From IdentityUser
        public int AccessFailedCount { get; set; }                      // From IdentityUser

        // Custom Fields
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Occupation { get; set; }
        public string? Location { get; set; }
        public List<string>? Interests { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // OTP
        public string? Otp { get; set; }
        public DateTime? OtpExpiresAt { get; set; }

    }
}