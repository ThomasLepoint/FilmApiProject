using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Models
{
    public class InsertComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime? Disable_at { get; set; }
        public string Reason { get; set; }
    }
    public class DeleteComment
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
    public class UpdateComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
    }
    public class CompleteComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public string MovieTitle { get; set; }
        public string Login { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created_at { get; set; }
    }
    public class UserComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime Created_at { get; set; }
    }
    public class MovieComment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Value { get; set; }
        public string Login { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created_at { get; set; }
    }
}
