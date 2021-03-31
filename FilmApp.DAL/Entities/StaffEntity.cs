using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public class StaffEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
