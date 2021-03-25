using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Repositories
{
    public class CommentRepository : IBaseRepository<Guid, CommentEntity>
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public CommentEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guid Insert(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(CommentEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
