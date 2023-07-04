using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.API.Controllers
{
    [Route("api/restaurant/menu/{menuId:Guid}/plate")]
    [ApiController]
    public class PlatesController : ControllerBase
    {
        private readonly IServices<PlateDto> _platesService;
        private readonly IMapper _mapper;

        public PlatesController(IServices<PlateDto> platesService, IMapper mapper)
        {
            _platesService = platesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid menuId, string uid)
        {
            IEnumerable<PlateDto> plates = await _platesService.GetAsync(uid, menuId);

            if (plates.Any())
            {
                return Ok(plates); 
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdAsync(Guid id)
        {
            PlateDto PlateDto = await _platesService.GetAsync(id);
            if (PlateDto is not null)
            {
                return Ok(PlateDto);
            }
           
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Guid menuId, PlateCreateDto createPlateDto)
        {
            PlateDto plate = _mapper.Map<PlateDto>(createPlateDto);
            plate.MenuId = menuId;
            PlateDto plateDtoCreated = await _platesService.CreateAsync(plate, menuId);

            if (plateDtoCreated is not null)
            {
                return Created(nameof(CreateAsync), plateDtoCreated);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PlateDto PlateDto)
        {
            PlateDto PlateDtoUpdated = await _platesService.UpdateAsync(id, PlateDto);

            if (PlateDtoUpdated is not null)
            {
                return Ok(PlateDtoUpdated);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            PlateDto PlateDtoDeleted = await _platesService.DeleteAsync(id);

            if (PlateDtoDeleted is not null) 
            {
                return Ok(PlateDtoDeleted); 
            }

            return NotFound();
        }
    }
}
