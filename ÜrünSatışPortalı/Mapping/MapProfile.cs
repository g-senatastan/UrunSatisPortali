using AutoMapper;
using ÜrünSatışPortalı.API.Dtos;
using ÜrünSatışPortalı.API.Models;
using ÜrünSatışPortalı.Dtos;
using ÜrünSatışPortalı.Models;

namespace ÜrünSatışPortalı.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AppRole, RoleDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AltCategory, AltCategoryDto>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
            
        }
    }
}
