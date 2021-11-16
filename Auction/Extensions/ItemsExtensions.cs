using Auction.Business.Contracts.Items;
using Auction.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Extensions
{
    public static class ItemsExtensions
    {
        public static UpdateItemCommand ToCommand(this CreateItemRequest request)
        {
            return new ()
            {   IsCreation = true,
                Name = request.Name,
                Description = request.Description,
                CurrentPrice = request.CurrentPrice,
                StartedPrice = request.StartedPrice,
            };
        }

        public static UpdateItemCommand ToCommand(this UpdateItemRequest request)
        {
            return new ()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                CurrentPrice = request.CurrentPrice,
                StartedPrice = request.StartedPrice,
            };
        }

        public static ItemDto ToDto(this ItemLot entity)
        {
            return new ()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CurrentPrice = entity.CurrentPrice,
                StartedPrice = entity.StartedPrice,
            };
        }
    }
}