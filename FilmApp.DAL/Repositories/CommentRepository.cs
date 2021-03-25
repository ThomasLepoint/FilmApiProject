using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
            throw new NotImplementedException();
        }

        public override bool Update(CommentEntity data)
        {
            throw new NotImplementedException();
        }

        protected override CommentEntity Convert(IDataRecord reader)
        {
            throw new NotImplementedException();
        }
    }
}
