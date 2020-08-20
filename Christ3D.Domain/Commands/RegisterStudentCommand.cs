using Christ3D.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Commands
{
    public class RegisterStudentCommand:StudentCommand
    {
        public RegisterStudentCommand()
        { }
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
        }

        public override bool IsValid()
        {
            FluentValidation.Results.ValidationResult ValidationResult =  new RegisterStudentCommandValidation().Validate(this);
            this.ValidationResult = ValidationResult;
            return ValidationResult.IsValid;
        }
    }
}
