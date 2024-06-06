using DAL.Entity;
using Dapper;
using System.Data;

namespace DAL.Repo
{
    public class BaseRepository<T> where T : BaseEntity, ITable
    {
        public readonly IDbConnection connection;

        public BaseRepository(ItalyFishersContext context)
        {
            connection = context.Connection;
        }

        public T Get(int id)
        {
            var query = $"SELECT * FROM {T.TableName} WHERE id={id}";
            return connection.Query<T>(query).FirstOrDefault()
                ?? throw new Exception("Not found");
        }

        public IEnumerable<T> GetAll()
        {
            var query = $"SELECT * FROM {T.TableName}";
            var q = connection.Query(query);
            return connection.Query<T>(query);
        }

        public void Delete(int id)
        {
            var query = $"DELETE FROM {T.TableName} WHERE id={id}";
            connection.Execute(query);
        }
    }
}
