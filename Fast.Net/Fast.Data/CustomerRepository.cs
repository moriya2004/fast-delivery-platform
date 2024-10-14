using Fast.Core.Entities;
using Fast.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Data
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }
        public Customer GetCustomerByTz(String tz)
        {
            return _context.Customers.Where(i => i.Tz == tz).FirstOrDefault();
        }
        public Customer Add(Customer customer)
        {
            var cust = _context.Customers.Where(i => i.Tz == customer.Tz).ToList();
            if (cust.Count > 0)
            {
                return null;
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        public Customer Update(int id, Customer customer)
        {
            var existCustomer = GetCustomerById(id);
            existCustomer.Name = customer.Name;
            existCustomer.Phone = customer.Phone;
            existCustomer.City = customer.City;
            _context.SaveChanges();
            return existCustomer;
        }
    }
}
