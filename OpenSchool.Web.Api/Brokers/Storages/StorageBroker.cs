using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OpenSchool.Web.Api.Brokers.StorageBroker
{
    public class StorageBroker : DbContext, IStorageBroker
    {
        private readonly IConfiguration configruation;

        public StorageBroker(IConfiguration configruation)
        {
            this.configruation = configruation;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connecionString = this.configruation.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connecionString);
        }

    }
}
