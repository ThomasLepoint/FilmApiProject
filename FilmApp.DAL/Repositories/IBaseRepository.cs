using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmApp.DAL.Repositories
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        // Create
        TKey Insert(TEntity entity);

        // Read
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();

        // Update
        bool Update(TEntity data);

        // Delete
        bool Delete(TEntity entity);
    }
}
