namespace DAL.Entity
{
    public class Status : BaseEntity, ITable
    {
        public string caption { get; set; }

        public static string TableName => "dbo.status";
    }
}
