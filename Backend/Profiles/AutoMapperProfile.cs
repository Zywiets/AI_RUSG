using AutoMapper;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.PurchaseHistory, opt => opt.MapFrom(src => src.PurchaseHistory));
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Player mappings
            CreateMap<Player, PlayerDto>();
            CreateMap<CreatePlayerDto, Player>();
            CreateMap<UpdatePlayerDto, Player>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // PurchaseHistory mappings
            CreateMap<PurchaseHistory, PurchaseHistoryDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .AfterMap((src, dest) =>
                {
                    dest.TotalPrice = src.UnitPrice * src.Quantity;
                });
            CreateMap<CreatePurchaseHistoryDto, PurchaseHistory>()
                .AfterMap((src, dest) =>
                {
                    dest.TotalPrice = src.UnitPrice * src.Quantity;
                });
            CreateMap<UpdatePurchaseHistoryDto, PurchaseHistory>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                .AfterMap((src, dest) =>
                {
                    if (src.UnitPrice.HasValue || src.Quantity.HasValue)
                    {
                        dest.TotalPrice = (src.UnitPrice ?? dest.UnitPrice) * (src.Quantity ?? dest.Quantity);
                    }
                });
        }
    }
}