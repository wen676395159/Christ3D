using Christ3D.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.Validations
{
    public class RegisterStudentCommandValidation:StudentValidation<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidation()
        {
            ValidateName();//验证姓名
            ValidateBirthDate();//验证年龄
            ValidateEmail();//验证邮箱
            //ValidatePhone();//验证手机号
            //可以自定义增加新的验证
        }
    }
}
