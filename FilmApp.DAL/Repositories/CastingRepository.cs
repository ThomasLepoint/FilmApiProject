using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public class CastingRepository : BaseRepository<Guid, CastingEntity>
    {
        public CastingRepository():base("Casting", "Id")
        { }
        public IEnumerable<CastingEntity> GetCasting(Guid Id)
        {
            Command cmd = new Command("SP_GetCasting", true);
            cmd.AddParameter("@IdMovie", Id);
            return _connection.ExecuteReader(cmd, Convert);
        }
        public bool AddCasting(List<CastingEntity> casting)
        {
            bool succes = true;
            foreach (CastingEntity cast in casting)
            {
                Command cmd = new Command("SP_AddCasting");
                cmd.AddParameter("@MovieId", cast.MovieId);
                cmd.AddParameter("@StaffId", cast.StaffId);
                cmd.AddParameter("@Character", cast.Character);
                succes = _connection.ExecuteNonQuery(cmd) >= 1;
            }
            return succes;
        }
        public bool UpdateCasting(List<CastingEntity> casting)
        {
            bool succes = true;
            foreach (CastingEntity cast in casting)
            {
                Command cmd = new Command("SP_UpdateCasting");
                cmd.AddParameter("@MovieId", cast.MovieId);
                cmd.AddParameter("@StaffId", cast.StaffId);
                cmd.AddParameter("@Character", cast.Character);
                succes = _connection.ExecuteNonQuery(cmd) >= 1;
            }
            return succes;
        }

        protected override CastingEntity Convert(IDataRecord reader)
        {
            return new CastingEntity() { 
            Id = Guid.Parse(reader["Id"].ToString()),
            MovieId = Guid.Parse(reader["MovieId"].ToString()),
            StaffId = Guid.Parse(reader["StaffId"].ToString()),
            FirstName = reader["FirstName"].ToString(),
            LastName = reader["LastName"].ToString(),
            BirthDate = (DateTime)reader["BirthDate"],
            Character = reader["Character"].ToString()
            };
        }

        public override Guid Insert(CastingEntity entity)
        {
            Command cmd = new Command("SP_AddCasting");
            cmd.AddParameter("@MovieId", entity.MovieId);
            cmd.AddParameter("@StaffId", entity.StaffId);
            cmd.AddParameter("@Character", entity.Character);
            return (Guid)_connection.ExecuteScalar(cmd);
        }

        public override bool Update(CastingEntity data)
        {
            Command cmd = new Command("SP_UpdateCasting");
            cmd.AddParameter("@MovieId", data.MovieId);
            cmd.AddParameter("@StaffId", data.StaffId);
            cmd.AddParameter("@Character", data.Character);
            return _connection.ExecuteNonQuery(cmd) >= 1;
        }

        public override bool Delete(Guid id, string Reason)
        {
            throw new NotImplementedException();
        }
    }
}
