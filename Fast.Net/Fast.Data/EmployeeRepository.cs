using Fast.Core.Entities;
using Fast.Core.Repository;
using Fast.Core.Sevice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Data
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IOrderService _orderService;
        public EmployeeRepository(DataContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
            _orderService = orderService;
        }
        public List<Employee> GetByArea(String area)
        {
            return _context.Employees.Where(i=>i.City.Area == area).ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Include(e => e.DeliveryType).FirstOrDefault(e => e.Id == id);
        }
        public Employee Update(int id, Employee employee)
        {
            var existEmployee = GetEmployeeById(id);
            existEmployee.Name = employee.Name;
            existEmployee.StartWorking = employee.StartWorking;
            existEmployee.Phone= employee.Phone;
            existEmployee.City= employee.City;
            existEmployee.DeliveryType= employee.DeliveryType;
            existEmployee.PaymentPerHour= employee.PaymentPerHour;
            _context.SaveChanges();
            return existEmployee;
        }
        public double GetSalary(int id)
        {
            var s = _orderService.GetOrdersByEmployeeId(id).Count();
            var e = GetEmployeeById(id);
            var sd= e.DeliveryType.Price;
            return s * sd;
        }

    }
}
