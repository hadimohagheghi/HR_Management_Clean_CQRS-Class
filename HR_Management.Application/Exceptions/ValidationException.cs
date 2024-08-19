using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace HR_Management.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {

        //public ValidationException(string message):base(message)
        //{


        //}
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationExceptions(ValidationResult validationResult)
        {

            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
