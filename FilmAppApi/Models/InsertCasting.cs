using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Models
{
    public class InsertCasting
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid StaffId { get; set; }
        public string Character { get; set; }
    }
}
