﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Config to Camel Casting for using Json
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //enable config
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
