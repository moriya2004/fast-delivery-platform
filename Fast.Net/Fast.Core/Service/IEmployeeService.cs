using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.Sevice
{
    public interface IEmployeeService
    {
        List<Employee> GetByArea(String area);
        Employee GetEmployeeById(int id);
        Employee Update(int id, Employee employee);
        double GetSalary(int id);
    }
}
