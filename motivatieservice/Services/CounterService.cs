using MongoDB.Driver;
using motivatieservice.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static motivatieservice.DataModels.CounterDataBaseSettings;

namespace motivatieservice.Services
{
    public class CounterService
    {
        private readonly IMongoCollection<Counter> _counter;

        public CounterService(ICounterDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _counter = database.GetCollection<Counter>(settings.CounterCollectionName);
        }


   //     public Book Get(string id) =>
  //          _books.Find<Book>(book => book.Id == id).FirstOrDefault();

   //     public Book Create(Book book)
  //     {
   //         _books.InsertOne(book);
   //         return book;
   //     }

    //    public void Update(string id, Book bookIn) =>
  //          _books.ReplaceOne(book => book.Id == id, bookIn);

    }
}
