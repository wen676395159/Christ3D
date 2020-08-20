using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.DomainCore.Commands
{
    public abstract class Command:IRequest
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; private set; }
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }
}
