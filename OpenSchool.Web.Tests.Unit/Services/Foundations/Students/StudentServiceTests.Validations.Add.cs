using Moq;
using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenSchool.Web.Tests.Unit.Services.Foundations.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async void ShouldThrowInvalidStudentExceptionWhenIdIsInvalidAsync()
        {

            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dateTime);
            Student inputStudent = randomStudent;
            inputStudent.Id =default;

            var invalidStudentInputException = new InvalidStudentException(
                parameterName: nameof(Student.Id),
                parameterValue: inputStudent.Id);

            var expectedStudentValidationException =
                new StudentValidationException(invalidStudentInputException);

            // when
            ValueTask<Student> registerStudentTask =
                this.studentService.RegisterStudentAsync(inputStudent);

            // then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                registerStudentTask.AsTask());

      
            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(It.IsAny<Student>()),
                    Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }



    }
}
