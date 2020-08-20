using Christ3D.DomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Events.Student
{
    public class StudentRegisteredEvent:Event
    {
        public StudentRegisteredEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
