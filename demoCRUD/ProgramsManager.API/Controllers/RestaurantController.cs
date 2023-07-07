using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models.Restaurant;

namespace ProgramsManager.API.Controllers
{

    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private IServices<RestaurantDto> _restaurantService;
        private IMapper _mapper;

        public RestaurantController(IServices<RestaurantDto> restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<RestaurantDto> restaurantDtos = await _restaurantService.GetAsync("");
            if (restaurantDtos.Any())
            {
                IEnumerable<RestaurantCreated> restaurantToShow = _mapper.Map<List<RestaurantCreated>>(restaurantDtos);
                return Ok(restaurantToShow);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            RestaurantDto restaurantDto = await _restaurantService.GetAsync(id);
            if (restaurantDto is not null)
            {
                return Ok(restaurantDto);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantCreateDto restaurantToCreate)
        {
            RestaurantDto restaurantDto = _mapper.Map<RestaurantDto>(restaurantToCreate);
            RestaurantDto restaurantDtoCreated = await _restaurantService.CreateAsync(restaurantDto);

            if (restaurantDtoCreated is not null)
            {
                RestaurantCreated restaurantCreated = _mapper.Map<RestaurantCreated>(restaurantDtoCreated);
                return Created(nameof(CreateAsync), restaurantCreated);
            }

            return BadRequest();
        }
    }
}
