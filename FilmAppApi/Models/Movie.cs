using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid ScriptWriterId { get; set; }
        public Guid DirectorId { get; set; }
    }
    public class CompleteMovie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid ScriptWriterId { get; set; }
        public Guid DirectorId { get; set; }
        public Staff Director { get; set; }
        public Staff ScriptWriter { get; set; }
        public IEnumerable<Casting> Casting { get; set; }
        public IEnumerable<MovieComment> Comments { get; set; }
    }
    public class InsertCompleteMovie
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Synopsis { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public Guid ScriptWriterId { get; set; }
        [Required]
        public Guid DirectorId { get; set; }
        public Staff Director { get; set; }
        public Staff ScriptWriter { get; set; }
        public IEnumerable<InsertCasting> Casting { get; set; }
    }
}
