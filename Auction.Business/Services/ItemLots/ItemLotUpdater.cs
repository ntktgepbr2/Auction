using System;
using System.Threading.Tasks;
using Auction.Business.Contracts.Items;
using Auction.Business.Exceptions;
using Auction.Business.Services.Users;
using Auction.Data.Repositories;
using Auction.Domain.Models;

namespace Auction.Business.Services.ItemLots
{
    public class ItemLotUpdater : IItemLotUpdater
    {

        private readonly IItemRepository _itemRepository;
        private readonly IUserService _userService;

        public ItemLotUpdater(IItemRepository itemRepository, IUserService userService)
        {
            _itemRepository = itemRepository;
            _userService = userService;
        }

        public async Task<ItemLot> Create(CreateItemCommand command)
        {
            var item = new ItemLot()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                StartedPrice = command.StartedPrice,
                CurrentPrice = command.CurrentPrice,
                CreatedDate = DateTimeOffset.UtcNow,
                User = await _userService.GetUserByEmail(command.Email),
            };
            item.LastUserBidId = item.User.Id;
            await _itemRepository.AddAsync(item);

            return item;
        }

        public async Task<ItemLot> Update(UpdateItemCommand command)
        {
            var item = await _itemRepository.GetEntity(command.Id);
            UpdateEntity(item, command);
            await _itemRepository.UpdateAsync(item);

            return item;
        }

        public async Task UpdateItemPrice(UpdateItemPriceCommand command)
        {
            var item = await _itemRepository.GetEntity(command.Id) ?? throw new EntityNotFoundException("Entity not found");
            var user = await _userService.GetUserByEmail(command.UserEmail);

            if (command.LastBid > item.CurrentPrice)
            {
                item.CurrentPrice = command.LastBid;
                item.LastUserBidId = user.Id;
                await _itemRepository.UpdatePriceAsync();
            }

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