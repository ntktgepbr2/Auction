﻿using Auction.Business.Services.ItemLots;
using Auction.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionsServiceCollectionExtensions
    {
        /// <summary>Adds the business layer dependency injections.</summary>
        /// <param name="services">The services.</param>
        public static void AddBusinessLayerDependencyInjections(this IServiceCollection services)
        {
            services
                .AddScoped<IItemLotService, ItemLotService>()
                .AddScoped<IItemLotFetcher, ItemLotFetcher>()
                .AddScoped<IItemLotUpdater, ItemLotUpdater>()
                .AddScoped<IItemLotRemover, ItemLotRemover>();
        }

        public static void AddDataLayerDependencyInjections(this IServiceCollection services)
        {
            services
                .AddSingleton<IItemLotRepository, MongoDbItemRepository>();
        }
    }
}