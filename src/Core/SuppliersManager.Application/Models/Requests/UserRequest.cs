
using System.ComponentModel.DataAnnotations;

namespace SuppliersManager.Application.Models.Requests
{
    public class UserRequest
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
