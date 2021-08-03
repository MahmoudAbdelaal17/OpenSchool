using System;

namespace OpenSchool.Web.Api.Models.Students.Exceptions
{
    public class AlreadyExistsStudentException : Exception
    {
        public AlreadyExistsStudentException()
            : base("Student with the same id already exists") { }
    }
}
