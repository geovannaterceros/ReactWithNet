using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models.Order;

namespace ProgramsManager.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServices<OrderDto> _orderService;
        private readonly IMapper _mapper;

        public OrderController(IServices<OrderDto> platesService, IMapper mapper)
        {
            _orderService = platesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<OrderDto> orders = await _orderService.GetAsync("");

            if (orders.Any())
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdAsync(Guid id)
        {
            OrderDto orderDto = await _orderService.GetAsync(id);
            if (orderDto is not null)
            {
                return Ok(orderDto);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderCreateDto createOrderDto)
        {
            OrderDto order = _mapper.Map<OrderDto>(createOrderDto);
            OrderDto orderDtoCreated = await _orderService.CreateAsync(order);

            if (orderDtoCreated is not null)
            {
                return Created(nameof(CreateAsync), orderDtoCreated);
            }

            return BadRequest();
        }
    }
}
