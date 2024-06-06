namespace DAL.Entity
{
    public class Person : BaseEntity, ITable
    {
        public int passport_id { get; set; }

        public string first_name { get; set; }

        public string middle_name { get; set; }

        public string last_name { get; set; }

        public static string TableName => "dbo.person";
    }
}