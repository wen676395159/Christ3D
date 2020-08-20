using AutoMapper;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using Christ3D.DomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.Interfaces
{
    public class StudengtAppService : IStudentAppService 
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IMapper _mapper;

        private readonly IMediatorHandler Bus;

        public StudengtAppService(IStudentRepository customerRepository,IMapper mapper,IMediatorHandler bus)
        {
            _studentRepository = customerRepository;
            _mapper = mapper;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel sutdengtViewModel)
        {
            //_studentRepository.Add(_mapper.Map<Student>(sutdengtViewModel));
            //_studentRepository.SaveChanges();
            RegisterStudentCommand registerStudentCommand = _mapper.Map<RegisterStudentCommand>(sutdengtViewModel);
            Bus.SendCommand(registerStudentCommand);

        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(studentViewModel));
        }
    }
}
