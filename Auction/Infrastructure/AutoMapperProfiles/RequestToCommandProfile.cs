using Auction.Business.Contracts.Items;
using Auction.Business.Contracts.Users;
using Auction.Contracts.Items;
using Auction.Data.Querying;
using Auction.Models;
using AutoMapper;

namespace Auction.Infrastructure.AutoMapperProfiles
{
    public class RequestToCommandProfile : Profile
    {
        public RequestToCommandProfile()
        {
            CreateMap<CreateItemRequest, CreateItemCommand>();
            CreateMap<UpdateItemRequest, UpdateItemCommand>();
            CreateMap<UserHashedCredentials, CreateUserCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(source => source.Hash));
            CreateMap<UserRegisterModel, UpdateUserCommand>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(source=> source.Email));
            CreateMap<BidItemRequest, UpdateItemPriceCommand>();
        }
    }
}
