﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2017_WebAPI2_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //一般MVC控制器的路由設定
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //路由設定放在越前面,優先權越高
            routes.MapRoute(
                name: "mis2000lab",   // 為了本範例作的修正
                url: "{controller}/{action}/{_ID}",    // 網址   /UserDB/Details/18
                defaults: new { controller = "UserDB", action = "List", _ID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",   // 預設值。預設的路由
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
