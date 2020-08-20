using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Commands
{
    public class UpdateStudentCommand : StudentCommand
    {
        public UpdateStudentCommand(string name, string email, DateTime birthDate, string phone)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
