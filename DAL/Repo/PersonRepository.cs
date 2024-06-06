using DAL.Entity;
using Dapper;

namespace DAL.Repo
{
    public class PersonRepository : BaseRepository<Person>, IRepository<Person>
    {
        public PersonRepository(ItalyFishersContext context) : base(context)
        {
        }
        
        public void Add(Person person)
        {
            var query = $"INSERT INTO {Person.TableName} VALUES (@id, @passport_id, @first_name, @middle_name, @last_name)";
            this.connection.Execute(query, person);
        }

        public void Update(int id, Person person)
        {
            var query = $"UPDATE {Person.TableName} SET passport_id = @passport_id, first_name = @first_name, last_name = @last_name, middle_name = @middle_name WHERE id={id}";
            this.connection.Execute(query, person);
        }
    }
}
