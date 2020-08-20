using Christ3D.Domain.Interfaces;
using Christ3D.DomainCore.Bus;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMediatorHandler _bus;

        private IMemoryCache _cache;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _cache = cache;
        }

        public bool Commit()
        {
            if (_unitOfWork.Commit())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
