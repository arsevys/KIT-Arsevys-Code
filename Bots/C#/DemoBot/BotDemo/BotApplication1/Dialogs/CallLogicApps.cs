using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using RestSharp;
namespace BotApplication1.Dialogs
{
    public class CallLogicApps
    {

        MyWebRequest http = null;

        public void correo()
        {

            var client = new RestClient("https://prod-04.northcentralus.logic.azure.com:443");
            var request = new RestRequest("/workflows/9e0734133f7e473caff5cdfd66c4ea9a/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Qs74NIElQnXU6nS1Gfc3Zr7euxuCPOgyi4e1ilzPax0", Method.GET);

            IRestResponse response = client.Execute(request);
            Debug.Print(response.Content);
            new MyWebRequest("https://prod-04.northcentralus.logic.azure.com:443/workflows/9e0734133f7e473caff5cdfd66c4ea9a/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Qs74NIElQnXU6nS1Gfc3Zr7euxuCPOgyi4e1ilzPax0", "GET");
        }

    }
}