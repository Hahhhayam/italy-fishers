using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ItalyFishersContext
    {
        public IConfiguration Configuration { get; init; }
        public ItalyFishersContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IDbConnection Connection { get => new SqlConnection(this.Configuration.GetConnectionString("dev"));}
    }
}
