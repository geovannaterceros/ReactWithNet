using AutoMapper;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.Models.Models.Order;
using ProgramsManager.Models.Models.Plate;

namespace ProgramsManager.DAL.AutoMapper
{
    public class PlateProfile : Profile
    {
        public PlateProfile()
        {
            CreateMap<PlateDto, Plate>().
                ForMember(x=> x.OrdersPlates, option => option.MapFrom(MapOrderPlate));

            CreateMap<Plate, PlateDto>()
               .ForMember(x => x.OrdersPlates, options => options.Ignore())
                .ForMember(x => x.Orders, options => options.MapFrom(MapOrders));

            CreateMap<PlateCreateDto, PlateDto>()
                .ForMember(x=> x.OrdersPlates, option => option.MapFrom(MapOrderPlates));

            CreateMap<PlateDto, PlateDtoCreated>();
        }

        private List<OrderPlateDto> MapOrderPlates(PlateCreateDto plateCreateDto, PlateDto plateDto) 
        {
            List<OrderPlateDto> result = new List<OrderPlateDto>();

            if (plateCreateDto.OrdersIds is null) 
            {
                return null;
            }

            foreach (Guid idOrder in plateCreateDto.OrdersIds) 
            {
                result.Add(new OrderPlateDto() { OrdenId = idOrder, PlateId = plateDto.Id });
            }

            return result;
        }

        private List<OrderPlate> MapOrderPlate(PlateDto plateDto, Plate plate)
        {
            List<OrderPlate> result = new List<OrderPlate>();

            if (plateDto.OrdersPlates is null) 
            {
                return null;
            }

            foreach (OrderPlateDto orderPlate in plateDto.OrdersPlates)
            {
                result.Add(new OrderPlate() { OrdenId = orderPlate.OrdenId, PlateId = orderPlate.PlateId });
            }

            return result;
        }

        private List<OrderDto> MapOrders(Plate plateDto, PlateDto plate)
        {
            List<OrderDto> result = new List<OrderDto>();

            if ( plateDto.OrdersPlates is null) 
            {
                return null;
            }

            foreach (OrderPlate orderPlate in plateDto.OrdersPlates)
            {
                if (orderPlate.Order is not null) {
                    result.Add(new OrderDto() { Id = orderPlate.Order.Id, NumberOrder = orderPlate.Order.NumberOrder });
                }
                
            }

            return result;
        }
    }
}
