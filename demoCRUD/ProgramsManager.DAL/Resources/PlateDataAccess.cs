using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.DAL.Resources
{
    public class PlateDataAccess : IDataAccess<PlateDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;
        public PlateDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<PlateDto> CreateAsync(PlateDto Plate, Guid? menuId)
        {
            Menu menu = await _projectContext.Menus.FirstAsync(x => x.Id.ToString() == menuId.ToString());

            if (menu is null)
            {
                return null;
            }

            Plate plateToCreate = _mapper.Map<Plate>(Plate);
            await _projectContext.AddAsync(plateToCreate);
            await _projectContext.SaveChangesAsync();

            return _mapper.Map<PlateDto>(plateToCreate);

        }

        public async Task<PlateDto> DeleteAsync(Guid id)
        {
            Plate PlateToDelete = await _projectContext.Plates
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (PlateToDelete is null)
            {
                return null; 
            }

            _projectContext.Remove(PlateToDelete);
            await _projectContext.SaveChangesAsync();

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateToDelete);

            return PlateDto;

        }

        public async Task<IEnumerable<PlateDto>> GetAsync<TId>(TId uid, Guid? menuId)
        {
            Menu menu = await _projectContext.Menus.FirstAsync(x=> x.Id.ToString() == menuId.ToString());
            
            if (menu is null) 
            {
                return null;
            }

            IEnumerable<Plate> plates = await _projectContext.Plates
                 .Where(plate => plate.UIDUser == uid.ToString())
                 .Include(x => x.OrdersPlates)
                 .ThenInclude(x => x.Order)
                 .ToListAsync();

            return _mapper.Map<List<PlateDto>>(plates);

        }

        public async Task<PlateDto> GetAsync(Guid id)
        {
            Plate PlateFound = await _projectContext.Plates
                  .Include(x => x.OrdersPlates)
                 .ThenInclude(x => x.Order)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (PlateFound is null) 
            {
                return null;
            }

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateFound);

            return PlateDto;
        }

        public async Task<PlateDto> UpdateAsync(Guid id, PlateDto entity)
        {
            Plate? PlateToUpdate = await _projectContext.Plates.FirstOrDefaultAsync(c=> c.Id == id);

            if (PlateToUpdate is null)
            {
                return null;
            }

            PlateToUpdate.Name = entity.Name;
            PlateToUpdate.DateActivity = entity.DateActivity;
            PlateToUpdate.Offer = entity.Offer;
            
            await _projectContext.SaveChangesAsync();

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateToUpdate);

            return PlateDto;
        }
    }
}
