using AutoMapper;
using Fast.API.Entities;
using Fast.Core.DTOs;
using Fast.Core.Entities;
using Fast.Core.Sevice;
using Fast.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }



        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            if (employeeDto == null)
                return NotFound();
            return employeeDto;
        }

        [HttpGet("salary/{id}")]
        public double GetSalary(int id)
        {
            double sum = _employeeService.GetSalary(id);
            return sum;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var employeeToUpdate = _mapper.Map<Employee>(employee);
            var updateEmployee = _employeeService.Update(id, employeeToUpdate);
            if (updateEmployee == null)
                return NotFound();
            return _mapper.Map<EmployeeDto>(updateEmployee);
        }

     

       

       


    }
}
