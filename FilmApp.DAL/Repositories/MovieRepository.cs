using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FilmApp.DAL.Repositories
{
    public class MovieRepository : BaseRepository<Guid, MovieEntity>
    {
        public MovieRepository() : base("Movies", "Id")
        {

        }
        public override bool Delete(Guid id, string Reason)
        {
            throw new NotImplementedException();
        }

        public override Guid Insert(MovieEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(MovieEntity data)
        {
            throw new NotImplementedException();
        }

        protected override MovieEntity Convert(IDataRecord reader)
        {
            throw new NotImplementedException();
        }
    }
}
