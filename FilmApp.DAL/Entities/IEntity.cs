using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
