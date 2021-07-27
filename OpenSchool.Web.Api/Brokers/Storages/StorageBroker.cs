using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenSchool.Web.Api.Models.Students;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : DbContext, IStorageBroker
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
