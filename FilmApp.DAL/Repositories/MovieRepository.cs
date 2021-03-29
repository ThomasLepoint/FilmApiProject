using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public class MovieRepository : BaseRepository<Guid, MovieEntity>
    {
        public MovieRepository() : base("Movies", "Id")
        {

        }
        public override bool Delete(MovieEntity movie)
        {
            throw new NotImplementedException();
        }
        public override Guid Insert(MovieEntity entity)
        {
            Command cmd = new Command("SP_AddMovie", true);
            cmd.AddParameter("@Title", entity.Title);
            cmd.AddParameter("@Synopsis", entity.Synopsis);
            cmd.AddParameter("@ReleaseDate", entity.ReleaseDate);

            return (Guid)_connection.ExecuteScalar(cmd);
        }

        public override bool Update(MovieEntity data)
        {
            Command cmd = new Command("SP_UpdateMovie", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@Title", data.Title);
            cmd.AddParameter("@Synopsis", data.Synopsis);
            cmd.AddParameter("@ReleaseDate", data.ReleaseDate);
            return _connection.ExecuteNonQuery(cmd) >= 1;
        }
        protected override MovieEntity Convert(IDataRecord reader)
        {
            return new MovieEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Title = reader["Title"].ToString(),
                Synopsis = reader["Synopsis"].ToString(),
                ReleaseDate = (DateTime)reader["ReleaseDate"]
            };
        }
    }
}
