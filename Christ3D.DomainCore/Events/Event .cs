using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.DomainCore.Events
{
    public abstract class Event:INotification
    {
        // 时间戳
        public DateTime Timestamp { get; private set; }

        // 每一个事件都是有状态的
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
