using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace HR_Management.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {

        //public ValidationException(string message):base(message)
        //{


        //}
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {

            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
