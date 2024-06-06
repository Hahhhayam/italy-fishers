namespace DAL.Entity
{
    public class Watersource : BaseEntity, ITable
    {
        public string name { get; set; }

        public int type_id { get; set; }
        
        public string adress { get; set; }

        public static string TableName => "dbo.watersource";
    }
}