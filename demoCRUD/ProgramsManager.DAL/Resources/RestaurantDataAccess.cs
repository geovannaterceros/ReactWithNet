using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Restaurant;

namespace ProgramsManager.DAL.Resources
{
    public class RestaurantDataAccess : IDataAccess<RestaurantDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;
        public RestaurantDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<RestaurantDto> CreateAsync(RestaurantDto restaurantDto, Guid? id = null)
        {
            
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDto);
            await _projectContext.Restaurants.AddAsync(restaurant);
            await _projectContext.SaveChangesAsync();

            return _mapper.Map<RestaurantDto>(restaurant);

        }

        public Task<RestaurantDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestaurantDto>> GetAsync<TId>(TId id, Guid? uid = null)
        {
            IEnumerable<Restaurant> restaurants = await _projectContext.Restaurants
                .ToListAsync();
            return _mapper.Map<List<RestaurantDto>>(restaurants);
        }

        public async Task<RestaurantDto> GetAsync(Guid id)
        {
           Restaurant restaurant = await _projectContext.Restaurants
                .Include(x=> x.Menus)
                .ThenInclude(x => x.Plates)
                .FirstOrDefaultAsync(x=> x.Id == id);

            return _mapper.Map<RestaurantDto>(restaurant);

        }

        public Task<RestaurantDto> UpdateAsync(Guid id, RestaurantDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
