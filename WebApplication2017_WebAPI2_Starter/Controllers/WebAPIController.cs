using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//********************************************************
using WebApplication2017_WebAPI2_Starter.Models_MVC_UserDB;
// 自己動手寫上命名空間 -- 「專案名稱.Models_MVC_UserDB」。
//********************************************************

namespace WebApplication2017_WebAPI2_Starter.Controllers
{
    /// <summary>
    /// 檢視畫面（UI網頁），放在根目錄底下，名為 index2_UserDB.html
    /// </summary>
    public class WebAPIController : ApiController
    {
        //*************************************   連結 MVC_UserDB 資料庫  ********************************* (start)
        #region
        private MVC_UserDBContext _db = new MVC_UserDBContext();
        // 如果沒寫上方的命名空間 --「專案名稱.Models」，就得寫成下面這樣，加註「Models.」字樣。
        // private Models.MVC_UserDBContext _db = new Models.MVC_UserDBContext();

        // 資料庫一旦開啟連線，用完就得要關閉連線與釋放資源。https://msdn.microsoft.com/zh-tw/library/system.web.mvc.controller_methods(v=vs.118).aspx
        protected override void Dispose(bool disposing)
        {   // 有開啟DB連結，就得動手關掉、Dispose這個資源。https://msdn.microsoft.com/zh-tw/library/system.idisposable.dispose(v=vs.110).aspx
            // 或是 官方網站的教材（程式碼）https://github.com/aspnet/Docs/blob/master/aspnet/mvc/overview/getting-started/introduction/sample/MvcMovie/MvcMovie/Controllers/MoviesController.cs
            if (disposing)
            {
                _db.Dispose();  //***這裡需要自己修改，例如 _db字樣
            }
            base.Dispose(disposing);
            // 資料庫一旦開啟連線，用完就得要關閉連線與釋放資源。
            // The base "Controller" class already implements the "IDisposable" interface, so this code simply adds an "override" to the 
            // "Dispose(bool)" method to explicitly dispose the context instance. 
            // ( "Dispose(bool)"方法標示為 virtual，所以可以用override覆寫。https://msdn.microsoft.com/zh-tw/library/dd492699(v=vs.118).aspx )

            // "Controller" class  https://msdn.microsoft.com/zh-tw/library/system.web.mvc.controller(v=vs.118).aspx
        }
        #endregion
        //*************************************   連結 MVC_UserDB 資料庫  ********************************* (end)


        //===================================
        //== 列表（Master） ==  無分頁功能。
        //===================================
        //public IEnumerable<UserTable> GetList()
        //{   // 傳統寫法
        //    IQueryable<UserTable> ListAll = from _userTable in _db.UserTables
        //                                                    select _userTable;
        //    // 或是寫成
        //    //var ListAll = from m in _db.UserTables
        //    //                   select m;

        //    return ListAll.ToList();
        //    // 直到程式的最後，把查詢結果 IQueryable呼叫.ToList()時，上面那一段LINQ才會真正被執行！
        //}
        public IHttpActionResult GetList()
        {   // 傳回值--(3)  IHttpActionResult
            IQueryable<UserTable> ListAll = from _userTable in _db.UserTables
                                                                select _userTable;
            return Ok(ListAll.ToList());   
            // returns an HttpStatusCode.OK   // https://docs.microsoft.com/zh-tw/previous-versions/aspnet/dn308866%28v%3dvs.118%29
        }



        //===================================
        //== 列出一筆記錄的明細（Details） ==
        //===================================
        //public UserTable GetDetails(int id)  
        //{   // 傳統寫法                                              
        //    UserTable ut = _db.UserTables.Find(id);

        //    return ut;
        //}
        public IHttpActionResult GetProduct(int id)
        {   // 傳回值 -- (3)  IHttpActionResult
            UserTable ut = _db.UserTables.Find(id);
            if (ut == null)
            {
                return NotFound();  // 找不到。這也是 Http.Results的一種，需搭配 IHttpActionResult使用
            }
            return Ok(ut);
            // returns an HttpStatusCode.OK   // https://docs.microsoft.com/zh-tw/previous-versions/aspnet/dn308866%28v%3dvs.118%29
        }

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
