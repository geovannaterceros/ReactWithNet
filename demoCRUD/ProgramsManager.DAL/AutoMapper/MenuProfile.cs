

using AutoMapper;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.Models.Models.Menu;

namespace ProgramsManager.DAL.AutoMapper
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuDto, Menu>();
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuCreateDto, MenuDto>();
             CreateMap<MenuDto, MenuCreateDto>();
            CreateMap<MenuDto, MenuDtoShow>();
        }
    }
}
