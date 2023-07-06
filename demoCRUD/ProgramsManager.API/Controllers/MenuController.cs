using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models.Menu;

namespace ProgramsManager.API.Controllers
{
    [ApiController]
    [Route("api/restaurant/{restaurantId:Guid}/menu")]
    public class MenuController : ControllerBase
    {
        private IServices<MenuDto> _menuServices;
        private IMapper _mapper;

        public MenuController(IServices<MenuDto> menuServices, IMapper mapper)
        {
            _menuServices = menuServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid restaurantId)
        {
            IEnumerable<MenuDto> menus = await _menuServices.GetAsync<Guid>(restaurantId);

            if (menus.Any())
            {
                IEnumerable<MenuDtoShow> menusToShow = _mapper.Map<List<MenuDtoShow>>(menus);
                return Ok(menusToShow);
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MenuCreateDto menuCreateDto, Guid restaurantId)
        {
            MenuDto menu = _mapper.Map<MenuDto>(menuCreateDto);
            MenuDto menuDtoCreated = await _menuServices.CreateAsync(menu, restaurantId);

            if (menuDtoCreated is not null)
            {
                MenuDtoShow menuShow = _mapper.Map<MenuDtoShow>(menuDtoCreated);
                return Created(nameof(CreateAsync), menuShow);
            }

            return BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid restaurantId, Guid id)
        {
            var restaurantDto = await _menuServices.GetAsync(id);
            if (restaurantDto is not null)
            {
                return Ok(restaurantDto);
            }
            return NoContent();
        }
    }
}
