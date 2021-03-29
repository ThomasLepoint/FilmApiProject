using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FilmApp.DAL.Entities;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public class UserRepository : BaseRepository<Guid, UserEntity>
    {
        public UserRepository():base("V_Users", "Id")
        { }
        protected override UserEntity Convert(IDataRecord reader)
        {
            return new UserEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Email = reader["Email"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                Password = null,
                Disable_at = (DateTime)reader["Deleted_at"],
                Reason = reader["Reason"].ToString(),
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }
        public override bool Delete(Guid id, string Reason)
        {
            Command cmd = new Command("SP_DisableUser", true);
            cmd.AddParameter("@Id", id);
            cmd.AddParameter("@Reason", Reason);

            return _connection.ExecuteNonQuery(cmd) >= 1;
        }

        public override Guid Insert(UserEntity entity)
        {
            Command cmd = new Command("SP_AddUser", true);
            cmd.AddParameter("@Login", entity.Login);
            cmd.AddParameter("@Email", entity.Email);
            cmd.AddParameter("@Password", entity.Password);
            cmd.AddParameter("@FirstName", entity.FirstName);
            cmd.AddParameter("@LastName", entity.LastName);
            if (entity.BirthDate != null)
            cmd.AddParameter("@BirthDate", entity.BirthDate);
            cmd.AddParameter("@IsAdmin", entity.IsAdmin);
            return (Guid)_connection.ExecuteScalar(cmd);
        }

        public override bool Update(UserEntity data)
        {
            Command cmd = new Command("SP_UpdateUser", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@Email", data.Email);
            cmd.AddParameter("@FirstName", data.FirstName);
            cmd.AddParameter("@LastName", data.LastName);
            cmd.AddParameter("@BirthDate", data.BirthDate);

            return _connection.ExecuteNonQuery(cmd) >= 1;
        }
        public UserEntity Login(string email, string password)
        {
            Command cmd = new Command("LoginUser", true);
            cmd.AddParameter("@Email", email);
            cmd.AddParameter("@Password", password);

            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }
        public bool SwitchRole(Guid guid)
        {
            Command cmd = new Command("SP_Switch_Role", true);
            cmd.AddParameter("@Id", guid);

            return _connection.ExecuteNonQuery(cmd) >= 1;
        }
    }
}
