﻿using MongoDB.Driver;
using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;

namespace Catalog.API.Data
{
    public class CatalogContextcs : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContextcs(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
    }
}
