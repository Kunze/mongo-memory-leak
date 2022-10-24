using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mongo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoCollection<BsonDocument> collection;

        public HomeController(IMongoCollection<BsonDocument> collection)
        {
            this.collection = collection;
        }

        public async Task<IActionResult> Index()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var results = await collection.FindAsync(filter);

            return View(results);
        }
    }
}
