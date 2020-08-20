using Christ3D.DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Models
{
    public class Student: Entity
    {
        protected Student() { }
        public Student(Guid id, string name, string email, DateTime birthDate,Address Address)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            address = Address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Address address { get; private set; }
    }
}
