using ProgramsManager.BL.Interfaces;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Order;

namespace ProgramsManager.BL.Resources
{
    public class OrderService : IServices<OrderDto>
    {
        private IDataAccess<OrderDto> _orderDataAccess;

        public OrderService(IDataAccess<OrderDto> orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }

        public async Task<OrderDto> CreateAsync(OrderDto entity, Guid? id = null)
        {
            return await _orderDataAccess.CreateAsync(entity, id);
        }

        public Task<OrderDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetAsync<T>(T id, Guid? uid = null)
        {
            return await _orderDataAccess.GetAsync<T>(id, uid);
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            return await _orderDataAccess.GetAsync(id);
        }

        public Task<OrderDto> UpdateAsync(Guid id, OrderDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
