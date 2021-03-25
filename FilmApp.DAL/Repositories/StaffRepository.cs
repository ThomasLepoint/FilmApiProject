using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
            throw new NotImplementedException();
        }

        public override bool Update(StaffEntity data)
        {
            throw new NotImplementedException();
        }

        protected override StaffEntity Convert(IDataRecord reader)
        {
            throw new NotImplementedException();
        }
    }
}
