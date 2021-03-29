using FilmApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Tools;

namespace FilmApp.DAL.Repositories
{
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        protected Connection _connection {get;}
        protected string TableName { get;  }
        protected string IdName { get; }
        public BaseRepository(string tableName, string idName = "Id")
        {
            _connection = new Connection(SqlClientFactory.Instance, @"Data Source=MSI\SQLEXPRESS;Initial Catalog=FilmApp.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            TableName = tableName;
            IdName = idName;
        }

        protected abstract TEntity Convert(IDataRecord reader);
        public abstract TKey Insert(TEntity entity);
        public virtual TEntity Get(TKey id)
        {
            Command cmd = new Command("SELECT * FROM [" + TableName + "] " +
                                     "WHERE " + IdName + " = @Id");
            cmd.AddParameter("@Id", id);

            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [" + TableName + "]");

            return _connection.ExecuteReader(cmd, Convert);
        }
        public abstract bool Update(TEntity data);
        public abstract bool Delete(TEntity entity);
    }
}
