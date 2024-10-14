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
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet("ByCustomer/{idCustomer}")]
        public ActionResult<IEnumerable<OrderDto>> GetByCustomerId(int idCustomer)
        {
            var orders = _orderService.GetOrdersByCustomerId(idCustomer);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        // GET: api/<OrderController>
        [HttpGet("ByEmployee/{idEmployee}")]
        public ActionResult<IEnumerable<OrderDto>> GetByEmployeeId(int idEmployee)
        {
            var orders = _orderService.GetOrdersByEmployeeId(idEmployee);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(ordersDto);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            var order = _orderService.GetOrderById(id);
            var orderDto=_mapper.Map<OrderDto>(order);
            if (orderDto == null)
                return NotFound();
            return orderDto;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<OrderDto> Post([FromBody] OrderPostModel order)
        {
            var orderToAdd = _mapper.Map<Order>(order);
            var newOrder = _orderService.Add(orderToAdd);
            if (newOrder == null)
                return NotFound();
            return _mapper.Map<OrderDto>(newOrder);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult<OrderDto> Put(int id, [FromBody] OrderPostModel order)
        {
            var orderToUpdate = _mapper.Map<Order>(order);
            var updateOrder = _orderService.Update(id, orderToUpdate);
            if (updateOrder == null)
                return NotFound();
            return _mapper.Map<OrderDto>(updateOrder);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }

    }
}
