using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Models
{
    public class UserWithComment
    {
        public Guid Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }

        public IEnumerable<UserComment> Comments { get; set; }
    }
}
