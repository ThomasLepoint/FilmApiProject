using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public class StaffRepository : BaseRepository<Guid, StaffEntity>
    {
        public StaffRepository() : base ("Staff", "Id")
        {

        }
        public override bool Delete(Guid id, string Reason)
        {
            throw new NotImplementedException();
        }

        public override Guid Insert(StaffEntity entity)
        {
            Command cmd = new Command("SP_AddStaff", true);
            cmd.AddParameter("@FirstName", entity.FirstName);
            cmd.AddParameter("@LastName", entity.LastName);
            cmd.AddParameter("@BirthDate", entity.BirthDate);

            return (Guid)_connection.ExecuteScalar(cmd);
        }
        public override bool Update(StaffEntity data)
        {
            Command cmd = new Command("SP_UpdateStaff", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@FirstName", data.FirstName);
            cmd.AddParameter("@LastName", data.LastName);
            cmd.AddParameter("@BirthDate", data.BirthDate);
            return _connection.ExecuteNonQuery(cmd) >= 1;
        }
        protected override StaffEntity Convert(IDataRecord reader)
        {
            return new StaffEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"]
            };
        }
    }
}
