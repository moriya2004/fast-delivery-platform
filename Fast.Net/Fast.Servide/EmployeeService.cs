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
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<Employee> GetByArea(String area)
        {
            return _employeeRepository.GetByArea(area);
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
        public Employee Update(int id, Employee employee)
        {
            return _employeeRepository.Update(id, employee);
        }
        public double GetSalary(int id)
        {
            return _employeeRepository.GetSalary(id);
        }
    }
}
