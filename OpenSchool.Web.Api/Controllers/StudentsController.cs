using Microsoft.AspNetCore.Mvc;
using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using OpenSchool.Web.Api.Services.Foundations.Students;

namespace OpenSchool.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            try
            {
                studentService.RegisterStudentAsync(student);
            }
            catch (InvalidStudentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Student Posted");
        }
    }
}
