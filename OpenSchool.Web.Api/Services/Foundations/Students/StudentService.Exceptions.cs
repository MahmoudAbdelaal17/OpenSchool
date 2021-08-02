﻿using OpenSchool.Web.Api.Models.Students;
using OpenSchool.Web.Api.Models.Students.Exceptions;
using System;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public partial class StudentService
    {
        private delegate ValueTask<Student> ReturningStudentFunction();

        private async ValueTask<Student> TryCatch(ReturningStudentFunction returningStudentFunction)
        {

            try
            {
                return await returningStudentFunction();
            }
            catch (InvalidStudentException invalidStudentException)
            {

                throw CreateAndLogValidationException(invalidStudentException);
            }
        }
            private StudentValidationException CreateAndLogValidationException(Exception exception)
            {
                var studentValidationException = new StudentValidationException(exception);
                this.loggerBroker.LogError(studentValidationException);

                return studentValidationException;
            }
        }
    }