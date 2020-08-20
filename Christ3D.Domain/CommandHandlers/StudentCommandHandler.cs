using Christ3D.Domain.Commands;
using Christ3D.Domain.Events.Student;
using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using Christ3D.DomainCore.Bus;
using FluentValidation.Internal;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Christ3D.Domain.CommandHandlers
{
    public class StudentCommandHandler:CommandHandler,
        IRequestHandler<RegisterStudentCommand,Unit>,
        IRequestHandler<UpdateStudentCommand,Unit>,
        IRequestHandler<RemoveStudentCommand,Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler _bus;
        private IMemoryCache _Cache;

        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache):base(unitOfWork,bus,cache)
        {
            _studentRepository = studentRepository;
            _bus = bus;
            _Cache = cache;
        }

        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                //错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            Student student = new Student(Guid.NewGuid(), request.Name, request.Email,request.BirthDate,request.address);

            _studentRepository.Add(student);

            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等
                _bus.RaiseEvent(new StudentRegisteredEvent(request.Id, request.Name, request.Email, request.BirthDate));
            }

            return Task.FromResult(new Unit());

        }

        private void NotifyValidationErrors(RegisterStudentCommand registerStudentCommand)
        { }


        public Task<Unit> Handle(UpdateStudentCommand message, CancellationToken cancellationToken)
        {
            // 省略...
            return Task.FromResult(new Unit());
        }

        // 同上，RemoveStudentCommand 的处理方法
        public Task<Unit> Handle(RemoveStudentCommand message, CancellationToken cancellationToken)
        {
            // 省略...
            return Task.FromResult(new Unit());
        }

        // 手动回收
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
