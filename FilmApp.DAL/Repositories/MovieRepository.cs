using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Repositories
{
    public class MovieRepository : IBaseRepository<Guid, MovieEntity>
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public MovieEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guid Insert(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(MovieEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
