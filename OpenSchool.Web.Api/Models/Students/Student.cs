using System;

namespace OpenSchool.Web.Api.Models.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDat { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset CreatedDate { get ; set; }
        public DateTimeOffset UpdatedDate { get ; set ; }
        public Guid CreatedBy { get ; set ; }
        public Guid UpdatedBy { get ; set ; }
    }
}
