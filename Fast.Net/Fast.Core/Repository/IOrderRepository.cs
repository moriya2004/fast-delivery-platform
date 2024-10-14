using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByCustomerId(int id);

        List<Order> GetOrdersByEmployeeId(int id);
        Order GetOrderById(int id);

        Order Add(Order order);

        void Delete(int id);

        Order Update(int id, Order order);
    }
}
