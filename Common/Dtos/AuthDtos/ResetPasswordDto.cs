namespace MbnakomAPIS.Common.Dtos
{
    public class ResetPasswordDto
    {
        /// <summary>
        /// Can be Email, Username, or Phone Number.
        /// </summary>
        public string LoginIdentifier { get; set; } = null!;
        public string OldPassword { get; set; } = null!; public string Opt { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmedPassword { get; set; } = null!;

    }
}
