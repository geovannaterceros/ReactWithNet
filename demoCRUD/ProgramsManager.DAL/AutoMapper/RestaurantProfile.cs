
using AutoMapper;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.Models.Models.Restaurant;

namespace ProgramsManager.DAL.AutoMapper
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantCreateDto, RestaurantDto>();
            CreateMap<RestaurantDto, RestaurantCreated>();

        }
    }
}
