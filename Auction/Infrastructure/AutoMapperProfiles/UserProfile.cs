using Auction.Contracts.Users;
using Auction.Domain.Models;
using AutoMapper;

namespace Auction.Infrastructure.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
