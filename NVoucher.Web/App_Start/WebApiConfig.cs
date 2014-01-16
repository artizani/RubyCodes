﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace NVoucher.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
           config.MapHttpAttributeRoutes();

           config.Routes.MapHttpRoute(
           name: "Codes",
           routeTemplate: "api/ProductResult/Codes",
           defaults: new { controller = "ProductResult" });

           config.Routes.MapHttpRoute(
           name: "Api",
           routeTemplate: "api/{controller}/{id}",
           defaults: new {id = RouteParameter.Optional});

           config.Routes.MapHttpRoute(
           name: "ActionApi",
           routeTemplate: "api/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }
);
          var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
          jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }



    }
}
