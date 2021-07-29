using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpenSchool.Web.Api.Models.Students;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> Students { get; set; }
        public async ValueTask<Student> InsertStudentAsync(Student student)
        {
            EntityEntry<Student> studentEntityEntry = await this.Students.AddAsync(student);
            await this.SaveChangesAsync();
            return studentEntityEntry.Entity;
        }
    }
}
