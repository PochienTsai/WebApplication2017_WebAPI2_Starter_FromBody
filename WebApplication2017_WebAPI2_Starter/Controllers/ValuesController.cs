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
    /// 預設的 WebAPI2範本
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // [FromBody]只能使用一次。 https://docs.microsoft.com/zh-tw/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api
        // 當參數具有 [FromBody] 時，Web API 會使用 Content-type 標頭來選取格式器。
        // 在此範例中，內容類型為 " application/json "  而且要求主體是原始的 json "字串"，"不是" json 物件。

        // 最多可以有一個參數從訊息主體讀取。 下面這種寫法 "無法運作"：
        // public HttpResponseMessage Post([FromBody] int id, [FromBody] string name) { ... }
        // 這項規則的原因是要求主體可能儲存在 "只能讀取一次" 的非緩衝資料流程中。

        [HttpPost]
        public IHttpActionResult Put([FromBody] JSONViewModel jsonViewModel)
        {
            jsonViewModel.Name += "**Updated（經過修改）**";
            // 把 Client端傳來的JSON，裡面的某一數值修改。

            return Ok(jsonViewModel);
        }
        //// 預設的範例。
        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}


        // 預設的範例。PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
