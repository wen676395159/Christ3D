using Christ3D.Application.ViewModels;
using Christ3D.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.Interfaces
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return null;
        }

        public CustomerViewModel GetById(Guid id)
        {
            return null;
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            //throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            //throw new NotImplementedException();
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            //throw new NotImplementedException();
        }
    }
}
