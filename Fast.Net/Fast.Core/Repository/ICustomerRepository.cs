using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        Customer GetCustomerByTz(String tz);
        Customer Add(Customer customer);
        Customer Update(int id,Customer customer);
    }
}
