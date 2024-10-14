using Fast.Core.Entities;
using Fast.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Data
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public List<Order> GetOrdersByCustomerId(int id)
        {
            return _context.Orders.Where(i=>i.CustomerId == id).ToList();
        }
        public List<Order> GetOrdersByEmployeeId(int id)
        {
            return _context.Orders.Where(i => i.EmployeeId == id && i.Status==false && i.Date.Date==DateTime.Now.Date).ToList();
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }
        public Order Add(Order order)
        {
            order.Customer = _context.Customers.Find(order.CustomerId);
            var cityArea = getAreaById(order.Customer.CityId);
            var employees = _context.Employees.ToList();
            for(int i = 0; i < employees.Count(); i++)
            {
                if (!getAreaById(employees[i].CityId).Equals(cityArea))
                    employees.Remove(employees[i]);
            }
            //List <Employee> employees = em.Where(i => getAreaById(i.CityId) ==cityId).ToList();
            Random rand=new Random();
            int index = rand.Next(0, employees.Count);
            order.Employee = employees[index];
            order.Date= DateTime.Now;
            order.Status = false;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        private String getAreaById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            City city = _context.Cities.Find(id);
            return city.Area;
        }
        public void Delete(int id)
        {
            var order = GetOrderById(id);
            if (order.Status == true)
                return;
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        public Order Update(int id, Order order)
        {
            var existOrder = GetOrderById(id);
            existOrder.Customer = order.Customer;
            existOrder.Employee = order.Employee;
            existOrder.Date = order.Date;
            existOrder.ToAddress = order.ToAddress;
            existOrder.Status=order.Status;
            _context.SaveChanges();
            return existOrder;
        }

    }
}
