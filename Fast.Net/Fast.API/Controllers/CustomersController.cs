using AutoMapper;
using Fast.API.Entities;
using Fast.Core.DTOs;
using Fast.Core.Entities;
using Fast.Core.Sevice;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            var customerDto= _mapper.Map<CustomerDto>(customer);
            if (customerDto == null)
                return NotFound();
            return customerDto;
        }
        [HttpGet("byTz/{tz}")]
        public ActionResult<CustomerDto> GetByTz(String tz)
        {
            var customer = _customerService.GetCustomerByTz(tz);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            if (customerDto == null)
                return NotFound();
            return customerDto;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<CustomerDto> Post([FromBody] CustomerPostModel customer)
        {
            var customerToAdd= _mapper.Map<Customer>(customer);
            var newCustomer = _customerService.Add(customerToAdd);
            if (newCustomer == null)
                return NotFound();
            return _mapper.Map< CustomerDto>(newCustomer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> Put(int id, [FromBody] CustomerPostModel customer)
        {
            var customerToUpdate = _mapper.Map<Customer>(customer);
            var updateCustomer = _customerService.Update(id, customerToUpdate);
            if (updateCustomer == null)
                return NotFound();
            return _mapper.Map<CustomerDto>(updateCustomer);
        }

    }
}
