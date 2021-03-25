using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public class CommentEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string  Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Disable_at { get; set; }
        public string Reason { get; set; }
        
    }
}
