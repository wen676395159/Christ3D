using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Commands
{
    public class RemoveStudentCommand: StudentCommand
    {
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
