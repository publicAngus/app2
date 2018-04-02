using System;
using StackExchange.Redis;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using app2.DB.Models;

namespace app2.Models.Providers{

    public interface IProvider
    {
        string Name{get;set;}
        string GetTestData();
    }

    public class TestProvider:IProvider{

        jumpmanjiContext dbctx;
        //app2.DB.TestCustomDb dbctx;
        public TestProvider(app2.DB.Models.jumpmanjiContext db){
            dbctx = db;
        }
         //public TestProvider(IOptions<app2.DB.Models.jumpmanjiContext> dbOpt){
           //  dbctx = dbOpt.Value;
         //}

        public TestProvider(string name){

            this.Name = name;
/*            
            using(var db = new jumpmanjiContext()){
                
                var item = new Users(){ Name=  DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss") };
                db.Users.Add(item);
                db.SaveChanges();
            }
*/
            

            /* 
            RdsConn = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase redisDb = RdsConn.GetDatabase();
            //redisDb.SetAdd("boo","lion");
            redisDb.StringSet("coo","coo-val");

            string vx = redisDb.StringGet("coo");
            */
        
        }

        public string GetTestData(){
            //return  "ffff";//$"{Configuration["ConfigVersion"]}";
            
            
             //using(var db = new app2.DB.Models.jumpmanjiContext()){
                 using(var db = dbctx){
                
                var ret = db.Users.OrderBy(t=>t.Id).Take(3).GroupJoin(db.UsersItems,t=>t.Id,i=>i.Userid,(t,i)=>new{
                        t.Id,
                        items = i
                }).ToList();
                return Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            
        }


        public string Name{
           get;set;
           }

        public ConnectionMultiplexer RdsConn {get;set;}
        
    }




}