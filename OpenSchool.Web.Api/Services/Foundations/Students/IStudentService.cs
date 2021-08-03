using OpenSchool.Web.Api.Models.Students;
using System.Threading.Tasks;
namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public interface IStudentService
    {
        ValueTask<Student> RegisterStudentAsync(Student student);
    }
}
