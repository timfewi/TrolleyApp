using AutoMapper;
using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ShoppingList, ShoppingListReadDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListCreateDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListUpdateDto>().ReverseMap();
            CreateMap<ShoppingList, ShoppingListDeleteDto>().ReverseMap();
        }
    }
}
