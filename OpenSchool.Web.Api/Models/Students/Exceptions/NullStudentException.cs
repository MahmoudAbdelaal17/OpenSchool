using System;

namespace OpenSchool.Web.Api.Models.Students.Exceptions
{
    public class NullStudentException : Exception
    {
        public NullStudentException() : base("The Student is null.") { }
    }
}
