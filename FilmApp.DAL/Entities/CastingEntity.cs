using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public class CastingEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid StaffId { get; set; }
        public string  LastName { get; set; }
        public string  FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string  Character { get; set; }
    }
}
