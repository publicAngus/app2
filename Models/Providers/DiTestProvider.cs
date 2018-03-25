using Microsoft.Extensions.Options;

namespace app2.Models.Providers{

    public class DiTestProvider:IProvider{
        private App.Appsettings settings{get;set;}
        public DiTestProvider(IOptions<App.Appsettings> settings){
            this.settings = settings.Value;
        }

        public string Name{get;set;}

        public string GetTestData(){
            return settings.DBCon;
        }

    }

}