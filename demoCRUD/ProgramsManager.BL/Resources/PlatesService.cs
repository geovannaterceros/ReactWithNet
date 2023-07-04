
using ProgramsManager.BL.Exceptions;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.BL.Validators;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.BL.Resources
{
    public class PlatesService : IServices<PlateDto>
    {
        private readonly IDataAccess<PlateDto> _plateDataAccess;
        
        public PlatesService(IDataAccess<PlateDto> plateDataAccess)
        {
            _plateDataAccess = plateDataAccess;
       
        }
        public async Task<PlateDto> CreateAsync(PlateDto entity, Guid? menuId = null)
        {
            PlateValidator _plateValidator = new PlateValidator();
            var validationResult = _plateValidator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new DtoValidationException(validationResult.Errors);
            }

            PlateDto PlateDtoCreated = await _plateDataAccess.CreateAsync(entity, menuId);

            return PlateDtoCreated;
        }

        public async Task<PlateDto> DeleteAsync(Guid id)
        {
            PlateDto PlateDtoDeleted = await _plateDataAccess.DeleteAsync(id);

            return PlateDtoDeleted;
        }

        public async Task<IEnumerable<PlateDto>> GetAsync<String>(String uid, Guid? menuId)
        {
            IEnumerable<PlateDto> PlateDtos = await _plateDataAccess.GetAsync(uid, menuId);

            return PlateDtos;
        }

        public async Task<PlateDto> GetAsync(Guid id)
        {
            PlateDto PlateDtoFound = await _plateDataAccess.GetAsync(id);

            return PlateDtoFound;
        }

        public Task<IEnumerable<PlateDto>> GetAsync<T>(T id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlateDto> UpdateAsync(Guid id, PlateDto entity)
        {
            PlateDto PlateDtoUpdated =  await _plateDataAccess.UpdateAsync(id, entity);

            return PlateDtoUpdated;
        }
    }
}
