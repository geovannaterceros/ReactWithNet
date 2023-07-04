
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models.Order;

namespace ProgramsManager.DAL.Resources
{
    public class OrderDataAccess : IDataAccess<OrderDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;

        public OrderDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateAsync(OrderDto entity, Guid? uid = null)
        {
            Order orderToCreate = _mapper.Map<Order>(entity);
            await _projectContext.AddAsync(orderToCreate);
            await _projectContext.SaveChangesAsync();
            OrderDto orderDto = _mapper.Map<OrderDto>(orderToCreate);

            return orderDto;
        }

        public Task<OrderDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetAsync<TId>(TId id, Guid? uid = null)
        {
            IEnumerable<Order> order = _projectContext.Orders
                .Include(x=> x.OrdensPlates)
                .ThenInclude(x => x.Plate)
                .ToList();

            return _mapper.Map<List<OrderDto>>(order);
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            Order order = await _projectContext.Orders
                .Include(x => x.OrdensPlates)
                .ThenInclude(x => x.Plate)
                .FirstOrDefaultAsync( x=> x.Id == id);

            OrderDto orderSearched = _mapper.Map<OrderDto>(order);

            return orderSearched;
        }

        public Task<OrderDto> UpdateAsync(Guid id, OrderDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
