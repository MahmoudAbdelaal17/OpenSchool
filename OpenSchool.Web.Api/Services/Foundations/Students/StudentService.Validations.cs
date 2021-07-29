using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public partial class StudentService
    {
        private static void ValidateStudentId(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new InvalidStudentException(
                    parameterName : nameof(studentId),
                    parameterValue: studentId);
            }
        }
    }
}
