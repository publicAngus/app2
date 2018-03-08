using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace app2.Filters{

    public class TestFilter:ActionFilterAttribute{
          
            public override void OnActionExecuting(ActionExecutingContext context){
                    string xx= "";
                    xx+="";
            }

            public override void OnActionExecuted(ActionExecutedContext context){
                   string xx= "";
                   xx+="";
            }

            

    }

}