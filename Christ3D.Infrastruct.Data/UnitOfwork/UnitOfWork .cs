using Christ3D.Domain.Interfaces;
using Christ3D.Infrastruct.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Infrastruct.Data.UnitOfwork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly StudyContext _context;

        public UnitOfWork(StudyContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        //手动回收
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
