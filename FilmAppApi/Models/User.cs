using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? Disable_Until { get; set; }
        public string Reason { get; set; }
    }
    public class UserRegister
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

    }
    public class UserLogin
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

    }
    public class DeleteUser
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
}
