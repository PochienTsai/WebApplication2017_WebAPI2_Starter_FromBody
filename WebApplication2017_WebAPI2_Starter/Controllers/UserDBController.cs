using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//********************************************************
using WebApplication2017_WebAPI2_Starter.Models_MVC_UserDB;  // 自己動手寫上命名空間 -- 「專案名稱.Models」。
//********************************************************


namespace WebApplication2017_WebAPI2_Starter.Controllers
{
    /// <summary>
    /// 檢視畫面（UI網頁），放在根目錄底下，名為 index3_MVC_UserDB.html
    /// 記得要修改 路由（/App_Start/RouteConfig.cs ）
    /// </summary>
    public class UserDBController : Controller
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

        //// 如果找不到動作（Action）或是輸入錯誤的動作名稱，一律跳回首頁
        //// Controller的 HandleUnknownAction方法為 virtual，所以可用override覆寫。https://msdn.microsoft.com/zh-tw/library/dd492730(v=vs.118).aspx

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect("http://公司首頁(網址)/");  // 自訂結果 -- 找不到動作就跳回首頁
        //    base.HandleUnknownAction(actionName);
        //}
        #endregion
        //*************************************   連結 MVC_UserDB 資料庫  ********************************* (end)


        // GET: UserDB
        public ActionResult Index()
        {
            return View();   // 空白的畫面與動作。 無作用。
        }


        //===================================
        //== 列表（Master） ==  無分頁功能。
        //===================================
        public JsonResult List()
        {      //****************
            IQueryable<UserTable> ListAll = from _userTable in _db.UserTables
                                                            select _userTable;
            // 或是寫成
            //var ListAll = from m in _db.UserTables
            //                   select m;
            
            return Json(ListAll.ToList(), JsonRequestBehavior.AllowGet);
            //                                   //*************************
            // 直到程式的最後，把查詢結果 IQueryable呼叫.ToList()時，上面那一段LINQ才會真正被執行！
        }


        //===================================
        //== 列出一筆記錄的明細（Details） ==
        //===================================
        public JsonResult Details(int _ID)  // 網址 http://xxxxxx/UserDB/Details?_ID=1 
        {   //****************
            // 如果沒有修改路由  /App_Start/RouteConfig.cs，網址輸入 http://xxxxxx/UserDB/Details/2 會報錯！ 
            UserTable ut = _db.UserTables.Find(_ID);

            return Json(ut, JsonRequestBehavior.AllowGet);
            //                  //*************************
        }

    }
}