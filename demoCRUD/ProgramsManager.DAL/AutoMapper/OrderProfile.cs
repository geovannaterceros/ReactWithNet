
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.Models.Models.Order;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.DAL.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto,  Order>()
                .ForMember(x => x.OrdensPlates, options => options.MapFrom(MapOrderPlate)); 

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrdensPlates, options => options.Ignore())
                 .ForMember(x => x.Plates, options => options.MapFrom(MapOrderWithPlate));

            CreateMap<OrderCreateDto, OrderDto>()
                .ForMember(x=> x.OrdensPlates, options => options.MapFrom(MapOrdersPlates));  

        }

        private List<PlateDto> MapOrderWithPlate(Order order, OrderDto orderDto) 
        {
            List<PlateDto> result = new List<PlateDto>();

            foreach (OrderPlate item in order.OrdensPlates)
            {
                result.Add(new PlateDto() { 
                    Id = item.PlateId, 
                    Name = item.Plate.Name,
                    Offer = item.Plate.Offer, 
                    DateActivity = item.Plate.DateActivity,
                    UIDUser = item.Plate.UIDUser, 
                    MenuId = item.Plate.MenuId });
            }
            return result;
        }
        private List<OrderPlateDto> MapOrdersPlates(OrderCreateDto orderCreateDto, OrderDto order) 
        {
            List<OrderPlateDto> result = new List<OrderPlateDto>();

            if (orderCreateDto.PlatesIds is null) 
            {
                return result;
            }

            foreach (Guid idPlate in orderCreateDto.PlatesIds) 
            {
                result.Add(new OrderPlateDto() { PlateId = idPlate, OrdenId = order.Id});
            }

            return result;
        }

        private List<OrderPlate> MapOrderPlate(OrderDto orderDto, Order order) 
        {
            List<OrderPlate> result = new List<OrderPlate>();

            foreach (OrderPlate item in order.OrdensPlates)
            {
                result.Add(new OrderPlate() { PlateId = item.PlateId, OrderId = orderDto.Id});
            }
            return result;
        }
    }
}
