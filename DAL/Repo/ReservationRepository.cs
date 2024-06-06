using DAL.Entity;
using Dapper;

namespace DAL.Repo
{
    public class ReservationRepository : BaseRepository<Reservation>, IRepository<Reservation>
    {
        public ReservationRepository(ItalyFishersContext context) : base(context)
        {
        }

        public void Add(Reservation reservation)
        {
            var query = $"INSERT INTO {Reservation.TableName} (id, person_id, watersource_id, status_id, created_at, start, [end]) VALUES (@id, @person_id, @watersource_id, @status_id, @created_at, @start, @end)";
            this.connection.Execute(query, reservation);
        }

        public void Update(int id, Reservation reservation)
        {
            var query = $"UPDATE {Reservation.TableName} SET person_id = @person_id, watersource_id = @watersource_id, status_id = @status_id, created_at = @created_at, start = @start, [end] = @end WHERE id={id}";
            this.connection.Execute(query, reservation);
        }
    }
}






