using Christ3D.Domain.Models;
using Christ3D.DomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Christ3D.Domain.Commands
{
    public abstract class StudentCommand : Command
    {
       public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public string Phone { get; protected set; }

        public Address address { get; protected set; }
    }
}
