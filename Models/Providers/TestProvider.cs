using System;

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
        }
        public string Name{
           get;set;
           }
    }

}