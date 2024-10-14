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
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }
        public List<Order> GetOrdersByCustomerId(int id)
        {
            return _orderRepository.GetOrdersByCustomerId(id);
        }
        public List<Order> GetOrdersByEmployeeId(int id)
        {
            return _orderRepository.GetOrdersByEmployeeId(id);
        }
        public Order Add(Order order)
        {
            var customer= _customerRepository.GetCustomerById(order.CustomerId);
            if (customer == null)
            {
                return null;
            }
            return _orderRepository.Add(order);
        }
        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }
        public Order Update(int id, Order order)
        {
            return _orderRepository.Update(id, order);
        }
    }
}
