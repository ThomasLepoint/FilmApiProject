using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Repositories
{
    public class StaffRepository : IBaseRepository<Guid, StaffEntity>
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public StaffEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StaffEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guid Insert(StaffEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(StaffEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
