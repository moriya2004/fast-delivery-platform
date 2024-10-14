using Fast.Core.Entities;
using Fast.Core.Repository;
using Fast.Core.Sevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }
        public Customer GetCustomerByTz(String tz)
        {
            return _customerRepository.GetCustomerByTz(tz);
        }
        public Customer Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
        public Customer Update(int id, Customer customer)
        {
            return _customerRepository.Update(id, customer);
        }
    }
}
