namespace DAL.Entity
{
    public class Reservation : BaseEntity, ITable
    {
        public int person_id { get; set; }

        public int watersource_id { get; set; }

        public int status_id { get; set; }

        public DateTime created_at { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public static string TableName => "dbo.reservation";
    }
}
