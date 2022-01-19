using Auction.Business.Contracts.Items;
using Auction.Business.Contracts.Users;
using Auction.Contracts.Items;
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
            CreateMap<UserRegisterModel, CreateUserCommand>();
            CreateMap<BidItemRequest, UpdateItemPriceCommand>();
        }
    }
}
