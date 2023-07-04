using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Menu;

namespace ProgramsManager.DAL.Resources
{
    public class MenuDataAccess : IDataAccess<MenuDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;

        public MenuDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }

        public async Task<MenuDto> CreateAsync(MenuDto entity, Guid? id = null)
        {
            IEnumerable<Restaurant> restaurants = await _projectContext.Restaurants.Where(restaurantDB => restaurantDB.Id.ToString() == id.ToString()).ToListAsync();

            if (!restaurants.Any())
            {
                return null;
            }

            Menu menu = _mapper.Map<Menu>(entity);
            menu.RestaurantId = restaurants.FirstOrDefault().Id;
            await _projectContext.AddAsync(menu);
            await  _projectContext.SaveChangesAsync();
            MenuDto menuCreated = _mapper.Map<MenuDto>(menu);

            return menuCreated;

        }

        public Task<MenuDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuDto> GetAsync(Guid id)
        {
            Menu menu =  _projectContext.Menus.Include(x=> x.Plates)
                .ThenInclude(x => x.OrdersPlates)
                .ThenInclude(x => x.Order)
                .FirstOrDefault(x => x.Id.ToString() == id.ToString());

            if (menu is null)
            {
                return null;
            }

            return _mapper.Map<MenuDto>(menu);
        }

       

        public async Task<IEnumerable<MenuDto>> GetAsync<TId>(TId restaurantId, Guid? uid)
        {
            IEnumerable<Restaurant> restaurants = await _projectContext.Restaurants
                .Where(restaurantDB => restaurantDB.Id.ToString() == restaurantId.ToString()).ToListAsync();

            if (!restaurants.Any())
            {
                return null;
            }

            IEnumerable<Menu> menus = await _projectContext.Menus
                .Include(x=> x.Plates)
                .ThenInclude(x => x.OrdersPlates)
                .ThenInclude(x => x.Order)
                .Where(x => x.RestaurantId.ToString() == restaurantId.ToString())
                .ToListAsync();

            return _mapper.Map<IEnumerable<MenuDto>>(menus);
        }

        public Task<MenuDto> UpdateAsync(Guid id, MenuDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
