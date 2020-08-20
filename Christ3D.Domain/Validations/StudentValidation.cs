﻿using Christ3D.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Validations
{
    public abstract class StudentValidation<T>: AbstractValidator<T> where T :StudentCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("姓名不能为空")
                .Length(2, 10).WithMessage("姓名在2-10个字符之间");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("学生应在14岁以上");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty()
                .Must(HavePhone)
                .WithMessage("手机号应该为11位！");
        }

        //验证Guid
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        // 表达式
        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-14);
        }
        // 表达式
        protected static bool HavePhone(string phone)
        {
            return phone.Length == 11;
        }
    }
}
