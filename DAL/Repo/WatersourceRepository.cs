using DAL.Entity;
using Dapper;

namespace DAL.Repo
{
    public class WatersourceRepository : BaseRepository<Watersource>, IRepository<Watersource>
    {
        public WatersourceRepository(ItalyFishersContext context) : base(context)
        {
        }

        public void Add(Watersource watersource)
        {
            var query = $"INSERT INTO {Watersource.TableName} (id, name, type_id, adress) VALUES (@id, @name, @type_id, @adress)";
            this.connection.Execute(query, watersource);
        }

        public void Update(int id, Watersource watersource)
        {
            var query = $"UPDATE {Watersource.TableName} SET name = @name, type_id = @type_id, adress = @adress WHERE id={id}";
            this.connection.Execute(query, watersource);
        }
    }
}