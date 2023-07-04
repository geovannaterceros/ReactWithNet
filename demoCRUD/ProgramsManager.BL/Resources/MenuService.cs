
using ProgramsManager.BL.Interfaces;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Menu;

namespace ProgramsManager.BL.Resources
{
    public class MenuService : IServices<MenuDto>
    {
        private IDataAccess<MenuDto> _menuDataAccess;

        public MenuService(IDataAccess<MenuDto> menuDataAccess)
        {
            _menuDataAccess = menuDataAccess;
        }

        public async Task<MenuDto> CreateAsync(MenuDto entity, Guid? id = null)
        {
            return await _menuDataAccess.CreateAsync(entity, id);
        }

        public Task<MenuDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuDto>> GetAsync<TId>(TId restaurantId, Guid? uid)
        {
            return await _menuDataAccess.GetAsync(restaurantId);
        }

        public async Task<MenuDto> GetAsync(Guid id)
        {
            return await _menuDataAccess.GetAsync(id);
        }

        public Task<MenuDto> UpdateAsync(Guid id, MenuDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
