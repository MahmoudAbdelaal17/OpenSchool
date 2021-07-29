using OpenSchool.Web.Api.Models.Students;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Student> InsertStudentAsync(Student student);
    }
}
