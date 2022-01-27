using Auction.Contracts.Items;
using Auction.Domain.Models;
using AutoMapper;

namespace Auction.Infrastructure.AutoMapperProfiles
{
    public class ItemLotProfile : Profile
    {
        public ItemLotProfile()
        {
            CreateMap<ItemLot, ItemDto>().ReverseMap();
        }
    }
}
