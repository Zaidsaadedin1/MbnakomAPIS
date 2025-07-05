using System.ComponentModel.DataAnnotations;

namespace MbnakomAPIS.Common.Dtos.UserDto
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Occupation { get; set; }
        public string? Location { get; set; }
        public List<string>? Interests { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;
    }
}
