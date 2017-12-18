using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace SantaClaus
{
  public class MongoDB : IDataBase
  {
    private IMongoDatabase database
    {
      get
      {
        return MongoConnection.Instance.Database;
      }
    }
    public IEnumerable<Order> GetAllOrder()
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("order");
      return orderCollection.Find(new BsonDocument()).ToList();
    }

    public IEnumerable<Toy> GetAllToy()
    {
      IMongoCollection<Toy> userCollection = database.GetCollection<Toy>("toy");
           return userCollection.Find(new BsonDocument()).ToList();
    }

        public Order GetOrder(string name)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("order");
      return orderCollection.Find(_ => _.Name == name).FirstOrDefault();
    }

    public User GetUser(User user)
    {
      IMongoCollection<User> userCollection = database.GetCollection<User>("user");
      return userCollection.Find(_ => _.UserName == user.UserName && _.Password == user.Password).FirstOrDefault();
    }

    public Toy GetToy(Toy toy)
    {
      IMongoCollection<Toy> toyCollection = database.GetCollection<Toy>("toy");
      return toyCollection.Find(_ => _.ToyName == toy.ToyName).FirstOrDefault();
    }

    public bool InsertOrder(Order order)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("order");
      try
      {
        orderCollection.InsertOne(order);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool InsertUser(User user)
    {
      IMongoCollection<User> userCollection = database.GetCollection<User>("user");
      try
      {
        userCollection.InsertOne(user);
        return true;
      }
      catch (Exception)
      {
        return false;
      }

    }

    public bool UpdateOrder(Order order)
    {
      IMongoCollection<Order> orderCollection = database.GetCollection<Order>("order");
      var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.ID));
      var update = Builders<Order>.Update
          .Set("name", order.Name);
      try
      {
        orderCollection.UpdateOne(filter, update);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool UpdateUser(User user)
    {
      IMongoCollection<User> UserCollection = database.GetCollection<User>("user");
      var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(user.ID));
      var update = Builders<User>.Update
          .Set("username", user.UserName)
          .Set("password", user.Password);
      try
      {
        UserCollection.UpdateOne(filter, update);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }



  }
}
