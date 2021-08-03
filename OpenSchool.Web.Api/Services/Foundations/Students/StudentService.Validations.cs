using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using System;

namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public partial class StudentService
    {
        private void ValidateStudentOnCreate(Student student)
        {
            switch (student)
            {
                case null:
                    throw new NullStudentException();
                case { } when IsInvalid(student.Id)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.Id),
                      parameterValue: student.Id);
                case { } when IsInvalid(student.FirstName)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.FirstName),
                      parameterValue: student.FirstName);
                case { } when IsInvalid(student.BirthDate)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.BirthDate),
                      parameterValue: student.BirthDate);
                case { } when IsInvalid(student.CreatedBy)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.CreatedBy),
                      parameterValue: student.CreatedBy);
                case { } when IsInvalid(student.UpdatedBy)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.UpdatedBy),
                      parameterValue: student.UpdatedBy);
                case { } when IsNotSame(student.CreatedDate, student.UpdatedDate)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.UpdatedDate),
                      parameterValue: student.UpdatedDate);
                case { } when IsNotSame(student.CreatedBy, student.UpdatedBy)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.UpdatedBy),
                      parameterValue: student.UpdatedBy);
                case { } when IsExist(student.Id)
                    :
                    throw new InvalidStudentException(
                      parameterName: nameof(student.Id),
                      parameterValue: student.Id);
            }
        }

        private bool IsExist(Guid id) =>
         id == Guid.Parse("9d4d6c5f-c266-45ca-ae33-ec1de299a5bb");

        private bool IsNotSame(Guid firstId, Guid secondId) =>
            firstId != secondId;

        private bool IsNotSame(DateTimeOffset firstDate, DateTimeOffset secondDate) =>
            firstDate != secondDate;

        private bool IsInvalid(Guid input) => input == default;
        private bool IsInvalid(string input) => input == default;
        private bool IsInvalid(DateTimeOffset input) => input == default;

    }
}
