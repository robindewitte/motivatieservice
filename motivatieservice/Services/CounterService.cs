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


        public Counter Get(string username) =>
           _counter.Find<Counter>(counter => counter.UserName == username).FirstOrDefault();

        public Counter Create(Counter counter)
       {
            _counter.InsertOne(counter);
            return counter;
        }

        public void Update(string username, Counter newCount) =>
            _counter.ReplaceOne(counter => counter.UserName == username, newCount);

        public string CountUp(string username)
        {
            if(Get(username) != null)
            {
                Counter old = Get(username);
                Counter up = new Counter();
                up.Id = old.Id;
                up.UserName = old.UserName;
                up.Count = old.Count + 1;
                Update(username, up);
                return up.Count.ToString();
            }
            else
            {
                Counter newcreate = new Counter();
                newcreate.UserName = username;
                newcreate.Count = 1;
                Create(newcreate);
                return "1";
            }
           
        }

    }
}
