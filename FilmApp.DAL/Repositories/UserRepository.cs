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
                Login = reader["Login"].ToString(),
                Email = reader["Email"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                Password = null,
                Disable_at = (DateTime)reader["Disable_at"],
                Reason = reader["Reason"].ToString(),
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }
        protected UserEntity ConvertLogin(IDataRecord reader)
        {
            return new UserEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Login = reader["Login"].ToString(),
                Email = reader["Email"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                Password = null,
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }
        public override bool Delete(UserEntity user)
        {
            Command cmd = new Command("SP_DisableUser", true);
            cmd.AddParameter("@Id", user.Id);
            cmd.AddParameter("@Reason", user.Reason);

            return _connection.ExecuteNonQuery(cmd) >= 1;
        }

        public override Guid Insert(UserEntity entity)
        {
            Command cmd = new Command("SP_Add_User", true);
            cmd.AddParameter("@Login", entity.Login);
            cmd.AddParameter("@Email", entity.Email);
            cmd.AddParameter("@Password", entity.Password);
            cmd.AddParameter("@FirstName", entity.FirstName);
            cmd.AddParameter("@LastName", entity.LastName);
            cmd.AddParameter("@BirthDate", entity.BirthDate);
            cmd.AddParameter("@IsAdmin", 0);
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
        public UserEntity Login(string login, string password)
        {
            Command cmd = new Command("SP_LoginUser", true);
            cmd.AddParameter("@Login", login );
            cmd.AddParameter("@Password", password);

            return _connection.ExecuteReader(cmd, ConvertLogin).SingleOrDefault();
        }
        public bool SwitchRole(Guid guid)
        {
            Command cmd = new Command("SP_Switch_Role", true);
            cmd.AddParameter("@Id", guid);

            return _connection.ExecuteNonQuery(cmd) >= 1;
        }
    }
}
