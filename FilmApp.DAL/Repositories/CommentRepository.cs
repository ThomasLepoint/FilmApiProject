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
        public override bool Delete(CommentEntity entity)
        {
            Command cmd = new Command("SP_DisableComment", true);
            cmd.AddParameter("@Id", entity.Id);
            cmd.AddParameter("@Reason", entity.Reason);
            return _connection.ExecuteNonQuery(cmd) >= 1;
        }

        public override Guid Insert(CommentEntity entity)
        {
            Command cmd = new Command("SP_AddStaff", true);
            cmd.AddParameter("@Title", entity.Title);
            cmd.AddParameter("@Content", entity.Content);
            cmd.AddParameter("@Value", entity.Value);
            cmd.AddParameter("@MovieId", entity.MovieId);
            cmd.AddParameter("@UserId", entity.UserId);

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
                Value = int.Parse(reader["Value"].ToString()),
                UserId = Guid.Parse(reader["UserId"].ToString()),
                MovieId = Guid.Parse(reader["Movie"].ToString()),
                Created_at = (DateTime)reader["Created_at"],
                Disable_at = (reader["Disabled_at"] is DBNull) ? null : (DateTime?)reader["Disabled_at"],
                Reason = reader["Reason"].ToString()
            };
        }
        protected MovieCommentEntity ConvertMovieComment(IDataRecord reader)
        {
            return new MovieCommentEntity()
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Title = reader["Title"].ToString(),
                Content = reader["Content"].ToString(),
                Value = int.Parse(reader["Value"].ToString()),
                MovieTitle = reader["MovieTitle"].ToString(),
                MovieId = Guid.Parse(reader["MovieId"].ToString()),
                UserId = Guid.Parse(reader["UserId"].ToString()),
                Login = reader["Login"].ToString(),
                Created_at = (DateTime)reader["Created_at"]
            };
        }
        public IEnumerable<CommentEntity> GetEveryComments()
        {
            Command cmd = new Command("SP_GetEveryComments", true);
            return _connection.ExecuteReader(cmd, Convert);
        }
        public IEnumerable<MovieCommentEntity> GetFullComments()
        {
            Command cmd = new Command("SP_GetFullComments", true);
            return _connection.ExecuteReader(cmd, ConvertMovieComment);
        }
        public IEnumerable<MovieCommentEntity> GetFilmComments(Guid IdMovie)
        {
            Command cmd = new Command("SP_GetMovieComments", true);
            cmd.AddParameter("@IdMovie", IdMovie);
            return _connection.ExecuteReader(cmd, ConvertMovieComment);
        }
        public IEnumerable<MovieCommentEntity> GetUserComments(Guid IdUser)
        {
            Command cmd = new Command("SP_GetMovieComments", true);
            cmd.AddParameter("@IdUser", IdUser);
            return _connection.ExecuteReader(cmd, ConvertMovieComment);
        }
    }
}
