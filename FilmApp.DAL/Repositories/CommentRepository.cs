using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public class CommentRepository : BaseRepository<Guid, CommentEntity>
    {
        public CommentRepository() : base("V_Comments", "Id")
        { }
        public override bool Delete(Guid id, string Reason)
        {
            throw new NotImplementedException();
        }

        public override Guid Insert(CommentEntity entity)
        {
            Command cmd = new Command("SP_AddStaff", true);
            cmd.AddParameter("@Title", entity.Title);
            cmd.AddParameter("@Content", entity.Content);
            cmd.AddParameter("@Value", entity.Value);

            return (Guid)_connection.ExecuteScalar(cmd);
        }

        public override bool Update(CommentEntity data)
        {
            Command cmd = new Command("SP_UpdateStaff", true);
            cmd.AddParameter("@Id", data.Id);
            cmd.AddParameter("@Title", data.Title);
            cmd.AddParameter("@Content", data.Content);
            cmd.AddParameter("@Value", data.Value);
            return _connection.ExecuteNonQuery(cmd) >= 1;
        }

        protected override CommentEntity Convert(IDataRecord reader)
        {
            return new CommentEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Title = reader["Title"].ToString(),
                Content = reader["Content"].ToString(),
                Value = int.Parse(reader["Value"].ToString())
            };
        }
    }
}
