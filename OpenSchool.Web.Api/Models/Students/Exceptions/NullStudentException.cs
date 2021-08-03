using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Models.Students.Exceptions
{
    public class NullStudentException : Exception
    {
        public NullStudentException() : base("The Student is null.") { }
    }
}
