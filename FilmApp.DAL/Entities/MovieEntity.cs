using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public class MovieEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid ScriptWriterId { get; set; }
        public Guid DirectorId { get; set; }
    }

}