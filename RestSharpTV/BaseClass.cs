using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System;
using RestSharpTV.Channels;
using Newtonsoft.Json;

namespace RestSharpTV
{

    public class BaseClass
    {

        /// <summary>
        /// read value from app.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigValue(string key) => ConfigurationManager.AppSettings[key];


        /// <summary>
        /// read the base url from config
        /// </summary>
        /// <returns></returns>
        private string GetBaseUrl()
        {
            string url = "";
            var environment = GetConfigValue("environment");
            switch (environment)
            {
                case "PPE":
                    url= GetConfigValue("PPE");
                    break;

                case "CGIE":
                    url=GetConfigValue("CGIE");
                    break;

                case "PROD":
                    url=GetConfigValue("PROD");
                    break;

                default: throw new ArgumentException(environment);
            }
            return url;
        }

        public IRestResponse GetResponse(Method RequestType,
                                         string resource,
                                         string Authorization,
                                         string token)
        {

            var client = new RestClient(GetBaseUrl());

            var req = new RestRequest(RequestType);

            req.Resource = resource;

            req.AddHeader(Authorization, token);

            var res= client.Execute(req);

            return res;
        }

     
    }
}
