using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Models.Students.Exceptions
{
    public class AlreadyExistsStudentException : Exception
    {
        public AlreadyExistsStudentException() 
            : base("Student with the same id already exists") {}
    }
}
