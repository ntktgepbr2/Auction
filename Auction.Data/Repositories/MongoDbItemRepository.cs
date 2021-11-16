using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auction.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Auction.Data.Repositories
{
    public class MongoDbItemRepository : IItemLotRepository
    {
        private const string DatabaseName = "catalog";
        private const string CollectionName = "items";

        private readonly IMongoCollection<ItemLot> _itemsCollection;
        private readonly FilterDefinitionBuilder<ItemLot> _filterBuilder = Builders<ItemLot>.Filter;
        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _itemsCollection = database.GetCollection<ItemLot>(CollectionName);
        }

        public async Task<List<ItemLot>> GetItemsAsync()
        {
            return await _itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<ItemLot> GetItemByIdAsync(Guid itemLotId)
        {
            var filter = _filterBuilder.Eq(item => item.Id, itemLotId);
            return await _itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateItemAsync(ItemLot item)
        {
            await _itemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(ItemLot item)
        {
            var result = _filterBuilder.Eq(item => item.Id, item.Id);
            await _itemsCollection.ReplaceOneAsync(result, item);

        }

        public async Task DeleteItemAsync(Guid itemLotId)
        {
            var result = _filterBuilder.Eq(item => item.Id, itemLotId);
            await _itemsCollection.DeleteOneAsync(result);
        }
    }
}