﻿using System;

namespace OpenSchool.Web.Api.Models.Students.Exceptions
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string parameterName, object parameterValue)
           : base($"Invalid Student, " +
                 $"ParameterName: {parameterName}, " +
                 $"ParameterValue: {parameterValue}.")
        { }
    }
}
