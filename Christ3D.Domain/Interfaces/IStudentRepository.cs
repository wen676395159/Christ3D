using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Interfaces
{
    /// <summary>
    /// customer仓储
    /// </summary>
    public interface IStudentRepository:IRepository<Student>
    {
        Student GetByEmail(string email);
    }
}
