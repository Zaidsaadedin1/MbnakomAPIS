namespace MbnakomAPIS.Common.Dtos.AuthDtos
{
    public class LoginUserDto
    {
        /// <summary>
        /// Can be Email, Username, or Phone Number.
        /// </summary>
        public string LoginIdentifier { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
