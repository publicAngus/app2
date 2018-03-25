namespace app2.Models.App{

    public class Logging{
        public bool IncludeScopes{get;set;}
        public string TestMsg{get;set;}
    }

   public class Appsettings
    {
        public string DBCon { get; set; }
        public string SiteName{get;set;}
    }
}