using System.Collections.Generic;
using Auction.Business.Contracts.Items;
using Auction.Contracts.Items;
using Auction.Domain.Models;

namespace Auction.Extensions
{
    public static class ItemsExtensions
    {
        public static CreateItemCommand ToCommand(this CreateItemRequest request, string userEmail)
        {
            return new ()
            {
                Name = request.Name,
                Description = request.Description,
                CurrentPrice = request.CurrentPrice,
                StartedPrice = request.StartedPrice,
                Email = userEmail,
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

        public static UpdateItemPriceCommand ToCommand(this BidItemRequest request, string userEmail)
        {
            return new()
            {
                Id = request.Id,
                LastBid = request.LastBid,
                UserEmail = userEmail,
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

        public static List<ItemDto> ToDto(this IReadOnlyCollection<ItemLot> itemList)
        {
            List<ItemDto> dtoList = new List<ItemDto>();

            foreach (ItemLot item in itemList)
            {
                ItemDto itemDto = new ItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CurrentPrice = item.CurrentPrice,
                    StartedPrice = item.StartedPrice,
                };

                dtoList.Add(itemDto);
            }

            return dtoList;
        }
    }
}
