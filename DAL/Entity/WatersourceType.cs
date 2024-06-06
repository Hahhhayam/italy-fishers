namespace DAL.Entity
{
    public class WatersourceType : BaseEntity, ITable
    {
        public string name { get; set; }

        public static string TableName => "dbo.watersource_type";
    }
}
