using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//********************************************************
using WebApplication2017_WebAPI2_Starter.Models;
//********************************************************

namespace WebApplication2017_WebAPI2_Starter.Controllers
{
    /// <summary>
    /// 檢視畫面（UI網頁），放在根目錄底下，名為 index.html
    /// </summary>
    public class ProductsController : ApiController
    {
        //此為微軟提供的範例
        #region  // 加入預設值（基本資料）
        // 程式沒有防呆，ID數字請勿重複！
        Product[] products = new Product[]
        {   
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
            new Product { Id = 4, Name = "張中文", Category = "Toys", Price = 5 },
            new Product { Id = 5, Name = "李法文", Category = "Hardware", Price = 6M },
            new Product { Id = 6, Name = "許功蓋(PHP)", Category = "Groceries", Price = 7 }
        };
        #endregion


        // 沒有輸入值。列出全部的資料。
        //public IEnumerable<Product> GetAllProducts()
        //{   // 原廠範例    // 傳回值 -- (4) 其他類型
        //    return products;  
        //}

        public IHttpActionResult GetAllProducts()
        {   // 傳回值 -- (3)  IHttpActionResult
            return Ok(products);

            // returns an HttpStatusCode.OK   // https://docs.microsoft.com/zh-tw/previous-versions/aspnet/dn308866%28v%3dvs.118%29
            // Http狀態碼(status code),常見的如下
            //200 OK
            //400 Bad Request 收到無效語法,而無法理解請求
            //404 Not Found 伺服器找不到請求的資源
            //500 Internal Server Error
        }

        //===========================================================

        // 需要一個輸入值。只列出「單一筆」資料。
        // 傳回值 -- (3)  IHttpActionResult
        public IHttpActionResult GetProduct(int id)
        {   // 原廠範例  // 傳回值 -- (3)  IHttpActionResult
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();  // 找不到。這也是 Http.Results的一種，需搭配 IHttpActionResult使用
            }
            return Ok(product);
            // returns an HttpStatusCode.OK   // https://docs.microsoft.com/zh-tw/previous-versions/aspnet/dn308866%28v%3dvs.118%29
        }

        //public Product GetProduct(int id)
        //{
        //    var pd = products.FirstOrDefault((p) => p.Id == id);
        //    if (pd == null)   {
        //        Product pdx = new Product()
        //        {
        //            Name = "找不到",
        //            Price = 0
        //        };
        //    return pdx;
        //    }
        //    return pd;
        //}

        //===========================================================
        // https://docs.microsoft.com/zh-tw/aspnet/web-api/overview/getting-started-with-aspnet-web-api/action-results
        // Web API 控制器動作可以傳回：
        //  (1)  void -- 傳回 "空"。204 （沒有內容）
        //  (2)  HttpResponseMessage -- 直接將轉換的 HTTP 回應訊息。
        //  (3)  IHttpActionResult -- 呼叫 .ExecuteAsync()來建立HttpResponseMessage，然後將轉換為 HTTP 回應訊息。
        //  (4)  其他類型 -- 將 序列化 的傳回值寫入至回應主體中; 傳回 200 （確定）。
        //                            缺點是您不能直接傳回錯誤碼 404 等。 不過，您可以擲回HttpResponseException錯誤代碼
        //===========================================================

    }
}
