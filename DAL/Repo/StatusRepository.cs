using DAL.Entity;
using Dapper;

namespace DAL.Repo
{
    public class StatusRepository : BaseRepository<Status>, IRepository<Status>
    {
        public StatusRepository(ItalyFishersContext context) : base(context)
        {
        }

        public void Add(Status status)
        {
            var query = $"INSERT INTO {Status.TableName} (id, caption) VALUES (@id, @caption)";
            this.connection.Execute(query, status);
        }

        public void Update(int id, Status status)
        {
            var query = $"UPDATE {Status.TableName} SET caption = @caption WHERE id={id}";
            this.connection.Execute(query, status);
        }
    }
}






