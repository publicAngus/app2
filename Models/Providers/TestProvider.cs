using System;
using StackExchange.Redis;

namespace app2.Models.Providers{

    public interface IProvider
    {
        string Name{get;set;}
    }

    public class TestProvider:IProvider{
        public TestProvider(string name){
            this.Name = name;
            using(var db = new jumpmanjiContext()){
                
                var item = new Users(){ Name=  DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss") };
                db.Users.Add(item);
                db.SaveChanges();
            }

            /*
            RdsConn = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase redisDb = RdsConn.GetDatabase();
            //redisDb.SetAdd("boo","lion");
            redisDb.StringSet("coo","coo-val");
            */
            

        }
        public string Name{
           get;set;
           }

        public ConnectionMultiplexer RdsConn {get;set;}
        
    }




}