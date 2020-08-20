using Christ3D.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.Interfaces
{
    public interface IStudentAppService :IDisposable
    {
        void Register(StudentViewModel customerViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel customerViewModel);
        void Remove(Guid id);
    }
}
