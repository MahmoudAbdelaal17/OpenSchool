﻿using Moq;
using OpenSchool.Web.Api.Brokers.Loggings;
using OpenSchool.Web.Api.Brokers.Storages;
using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Services.Foundations.Students;
using System;
using Tynamix.ObjectFiller;

namespace OpenSchool.Web.Tests.Unit.Services.Foundations.Students
{
    public partial class StudentServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IStudentService studentService;
        public StudentServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.studentService = new StudentService(
                storageBrokerMock.Object,loggingBrokerMock.Object);
        }

        private static Student CreateRandomStudent(DateTimeOffset dates) 
            => CreateStudentFilter(dates).Create();

        private static DateTimeOffset GetRandomDateTime()
        {
            return new DateTimeRange(earliestDate:new DateTime()).GetValue();
        }
        private static Filler<Student> CreateStudentFilter(DateTimeOffset dates)
        {
            var filler = new Filler<Student>();
            Guid CreatedBy = Guid.NewGuid();

            filler.Setup()
                .OnProperty(student => student.BirthDate).Use(GetRandomDateTime())
                .OnProperty(student => student.CreatedDate).Use(dates)
                .OnProperty(student => student.UpdatedDate).Use(dates)
                .OnProperty(student => student.CreatedBy).Use(CreatedBy)
                .OnProperty(student => student.UpdatedBy).Use(CreatedBy);

            return filler;
        }
    }
}
