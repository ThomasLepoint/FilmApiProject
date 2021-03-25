using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public class UserEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Disable_at { get; set; }
        public string Reason { get; set; }
    }
}
