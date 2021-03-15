using System.ComponentModel.DataAnnotations;

namespace AssetsManagement.RESTApi.Models
{
    public readonly struct RegisterModel
    {
        [Required, EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Username { get; init; }
        [Required]
        public string[] RoleNames { get; init; }
        [Required]
        public string Password { get; init; }
    }
}
