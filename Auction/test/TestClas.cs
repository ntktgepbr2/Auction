using System;
using System.Collections.Generic;
using Auction.Domain.Models;

namespace Auction.test
{
    public class TestClas
    {
        private readonly List<ItemLot> _itemLots = new()
        {
            new ItemLot
            {
                Id = Guid.NewGuid(),
                Name = "Macbook",
                Description = "Pretty new Macbook 2019",
                StartedPrice = 2550,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new ItemLot
            {
                Id = Guid.NewGuid(),
                Name = "Pixel",
                Description = "Best android phone",
                StartedPrice = 599,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new ItemLot
            {
                Id = Guid.NewGuid(),
                Name = "Lenovo Legion 5",
                Description = "Best gaming laptop in 2021",
                StartedPrice = 1300,
                CreatedDate = DateTimeOffset.UtcNow
            },
        };

        public  ItemLot ListMethod()
        {
            return _itemLots.Find(x => x.Name.Contains("5"));
        }
    }
}
