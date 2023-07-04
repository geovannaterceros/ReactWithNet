
using ProgramsManager.BL.Interfaces;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Restaurant;

namespace ProgramsManager.BL.Resources
{
    public class RestaurantService : IServices<RestaurantDto>
    {
        private IDataAccess<RestaurantDto> _restaurantDataAccess;

        public RestaurantService( IDataAccess<RestaurantDto> restaurantDataAccess)
        {
            _restaurantDataAccess = restaurantDataAccess;
        }

        public async Task<RestaurantDto> CreateAsync(RestaurantDto entity, Guid? id = null)
        {
            RestaurantDto restaurantCreated = await _restaurantDataAccess.CreateAsync(entity);
            return restaurantCreated;
        }

        public Task<RestaurantDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestaurantDto>> GetAsync<String>(String id, Guid? uid)
        {
            IEnumerable<RestaurantDto> restaurantDtos = await _restaurantDataAccess.GetAsync(id);
            return restaurantDtos;
        }

        public async Task<RestaurantDto> GetAsync(Guid id)
        {
            return await _restaurantDataAccess.GetAsync(id);
        }

        public Task<RestaurantDto> UpdateAsync(Guid id, RestaurantDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
