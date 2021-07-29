using System.Linq;
using System.Threading.Tasks;
using OpenSchool.Web.Api.Models.Students;
namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> RegisterStudentAsync(Student student);
    }
}
