using FluentAssertions;
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
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenStudentIsNull()
        {
            // Given 
            Student randomStudent = null;
            Student nullStudent = randomStudent;

            var nullStudentException = new NullStudentException();

            // When 
          ValueTask<Student> registerStudentTask = 
                this.studentService.RegisterStudentAsync(nullStudent);

            // Then 
            await Assert.ThrowsAsync<StudentValidationException>(() =>
               registerStudentTask.AsTask()
           );

            this.storageBrokerMock.Verify(broker => 
            broker.InsertStudentAsync(It.IsAny<Student>()), 
            Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenFirstNameIsNull()
        {
            // Given 
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.FirstName = null;

            // When 
            ValueTask<Student> registerStudentAsync = 
                this.studentService.RegisterStudentAsync(randomStudent);

            // Then 
             await Assert.ThrowsAsync<StudentValidationException>(() =>
                    registerStudentAsync.AsTask() );

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(randomStudent),
                Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenBrithDateIsInvalid()
        {
            //Given 
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.BirthDate = default;

            //When
            ValueTask<Student> registerStudentAsync =
                this.studentService.RegisterStudentAsync(randomStudent);

            //Then 
            await Assert.ThrowsAsync<StudentValidationException>(() => 
                registerStudentAsync.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(randomStudent),
                    Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenCreatedByIsInvalid()
        {
            //Given
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.CreatedBy = default;

            //When 
            ValueTask<Student> registerStudentAsync =
                this.studentService.RegisterStudentAsync(randomStudent);

            //Then 
            await Assert.ThrowsAsync<StudentValidationException>(() =>
               registerStudentAsync.AsTask()
            );

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(randomStudent),
                Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenUpdatedByIsInvalid()
        {
            //given 
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.UpdatedBy = default;

            //when
            ValueTask<Student> registerStudentAsync = 
                this.studentService.RegisterStudentAsync(randomStudent);

            //then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
               registerStudentAsync.AsTask()
            );

            this.storageBrokerMock.Verify(broker => 
                broker.InsertStudentAsync(randomStudent),
                Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenUpdateDateIsInvalid()
        {
            //given
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.UpdatedDate = default;

            //when
            ValueTask<Student> registerStudentAsync =
                this.studentService.RegisterStudentAsync(randomStudent);

            //then
            await Assert.ThrowsAsync<StudentValidationException>(() =>
                     registerStudentAsync.AsTask() );

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(randomStudent),
                Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenCreatedByNotSameAsUpdatedBy()
        {
            //given
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            randomStudent.UpdatedBy = Guid.NewGuid();

            //when
            ValueTask<Student> registerStudentAsync =
                this.studentService.RegisterStudentAsync(randomStudent);

            //then 
            await Assert.ThrowsAsync<StudentValidationException>(() =>
               registerStudentAsync.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(randomStudent),
                Times.Never());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenStudentAlreadyExist()
        {
            //given
            DateTimeOffset dates = GetRandomDateTime();
            Student randomStudent = CreateRandomStudent(dates);
            Student alreadyExistsStudent = randomStudent;
            alreadyExistsStudent.UpdatedBy = alreadyExistsStudent.CreatedBy;
            string randomMessage = GetRandomMessage();
            string exceptionMessage = randomMessage;
            var alreadyExistsStudentException = new AlreadyExistsStudentException();


            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(alreadyExistsStudent)).
                ThrowsAsync(alreadyExistsStudentException);

            //when
            ValueTask<Student> registerStudentAsync = 
                this.studentService.RegisterStudentAsync(alreadyExistsStudent);

            //then 
            await Assert.ThrowsAsync<StudentValidationException>(() =>
               registerStudentAsync.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(alreadyExistsStudent),
                Times.Once());

        }
    }
}
