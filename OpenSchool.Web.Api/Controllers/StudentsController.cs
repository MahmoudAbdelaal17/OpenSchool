using Microsoft.AspNetCore.Mvc;
using OpenSchool.Web.Api.Brokers.Storages;
using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using OpenSchool.Web.Api.Services.Foundations.Students;
using RESTFulSense.Controllers;
using System;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : RESTFulController
    {
        private readonly IStudentService studentService;
        private readonly IStorageBroker storageBroker;
        public StudentsController(IStorageBroker storageBroker , IStudentService studentService)
        {
            this.storageBroker = storageBroker;   
            this.studentService = studentService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<Student>> PostStudentAsync(Student student)
        {
            try
            {
                Student registerStudent = 
                    await this.studentService.RegisterStudentAsync(student);
                return Created(registerStudent);
            }
            catch (StudentValidationException studentValidationException) 
                when(studentValidationException.InnerException is AlreadyExistsStudentException)
            {
                string innerMessage = GetInnerMessage(studentValidationException);
                return Conflict(innerMessage);
            }
            catch (StudentValidationException studentValidationException)
            {
                string innerMessage = GetInnerMessage(studentValidationException);
                return BadRequest(innerMessage);
            }
        }

        private static string GetInnerMessage(Exception exception) =>
            exception.InnerException.Message;
        
    }
}
