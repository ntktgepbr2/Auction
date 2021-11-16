using System;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotUpdater : IItemLotUpdater
    {

        private readonly IItemLotRepository _itemLotRepository;

        public ItemLotUpdater(IItemLotRepository itemLotRepository)
        {
            _itemLotRepository = itemLotRepository;
        }

        public async Task<ItemLot> Update(UpdateItemCommand command)
        {
            ItemLot item;

            if (command.IsCreation)
            {
                 item = new ItemLot()
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    Description = command.Description,
                    StartedPrice = command.StartedPrice,
                    CurrentPrice = command.CurrentPrice,
                    CreatedDate = DateTimeOffset.UtcNow,
                };
                await _itemLotRepository.CreateItemAsync(item);

                return item;
            }

            item = await _itemLotRepository.GetItemByIdAsync(command.Id);
            UpdateEntity(item, command);
            await _itemLotRepository.UpdateItemAsync(item);

            return item;
        }

        private static ItemLot UpdateEntity(ItemLot item, UpdateItemCommand command)
        {
            item.Name = command.Name;
            item.Description = command.Description;
            item.CurrentPrice = command.CurrentPrice;
            item.StartedPrice = command.StartedPrice;

            return item;
        }
    }
}