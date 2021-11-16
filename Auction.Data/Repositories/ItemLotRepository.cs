//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Auction.Domain.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Auction.Data.Repositories
//{
//    public class ItemLotRepository : IItemLotRepository
//    {
//        private readonly List<ItemLot> _itemLots = new()
//        {
//            new ItemLot
//            {
//                Id = Guid.NewGuid(),
//                Name = "Macbook",
//                Description = "Pretty new Macbook 2019",
//                StartedPrice = 2550,
//                CreatedDate = DateTimeOffset.UtcNow
//            },
//            new ItemLot
//            {
//                Id = Guid.NewGuid(),
//                Name = "Pixel",
//                Description = "Best android phone",
//                StartedPrice = 599,
//                CreatedDate = DateTimeOffset.UtcNow
//            },
//            new ItemLot
//            {
//                Id = Guid.NewGuid(),
//                Name = "Lenovo Legion 5",
//                Description = "Best gaming laptop in 2021",
//                StartedPrice = 1300,
//                CreatedDate = DateTimeOffset.UtcNow
//            },
//        };

//        public List<ItemLot> GetItems()
//        {
//            return _itemLots;
//        }

//        public ItemLot GetById(Guid itemLotId)
//        {

//            return _itemLots.Where(i => i.Id == itemLotId).SingleOrDefault();
//        }

//        public void CreateItem(ItemLot item)
//        {
//            _itemLots.Add(item);
//        }

//        public ItemLot UpdateItem(ItemLot item)
//        {
//            return _itemLots.Find(_itemLots.Where(item => item.Id == item.Id).SingleOrDefault());
//        }

//        public void DeleteItem(Guid itemLotId)
//        {
//            _itemLots.Remove(_itemLots.Where(item => item.Id == itemLotId).SingleOrDefault());
//        }
//    }
//}
