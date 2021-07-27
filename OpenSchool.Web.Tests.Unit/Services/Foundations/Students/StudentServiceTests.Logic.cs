using FluentAssertions;
using Moq;
using OpenSchool.Web.Api.Models.Students;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenSchool.Web.Tests.Unit.Services.Foundations.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldRegisterStudentAsync()
        {
            // given
            DateTimeOffset randomDateTime = GetRandomDateTime();
            DateTimeOffset dateTime = randomDateTime;
            Student randomStudent = CreateRandomStudent(randomDateTime);
            randomStudent.UpdatedBy = randomStudent.CreatedBy;
            Student inputStudent = randomStudent;
            Student storageStudent = randomStudent;
            Student expectedStudent = storageStudent;

           
            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentAsync(inputStudent))
                    .ReturnsAsync(storageStudent);

            // when
            Student actualStudent =
                await this.studentService.RegisterStudentAsync(inputStudent);

            // then
            actualStudent.Should().BeEquivalentTo(expectedStudent);

            
            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentAsync(inputStudent),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

      
    }
}
