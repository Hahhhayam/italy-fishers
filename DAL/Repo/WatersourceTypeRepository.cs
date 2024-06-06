using DAL.Entity;
using Dapper;

namespace DAL.Repo
{
    public class WatersourceTypeRepository : BaseRepository<WatersourceType>, IRepository<WatersourceType>
    {
        public WatersourceTypeRepository(ItalyFishersContext context) : base(context)
        {
        }

        public void Add(WatersourceType type)
        {
            var query = $"INSERT INTO {WatersourceType.TableName} (id, name) VALUES (@id, @name)";
            this.connection.Execute(query, type);
        }

        public void Update(int id, WatersourceType type)
        {
            var query = $"UPDATE {WatersourceType.TableName} SET name = @name WHERE id={id}";
            this.connection.Execute(query, type);
        }
    }
}






