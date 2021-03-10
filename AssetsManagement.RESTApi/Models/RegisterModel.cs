using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
