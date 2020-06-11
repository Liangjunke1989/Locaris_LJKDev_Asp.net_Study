using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_10
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            UserInfoService userInfoService=new UserInfoService();
            UserInfoEntity userInfoEntity = userInfoService.GetUserInfoByUserId(id);
            JavaScriptSerializer javaScriptSerializer=new JavaScriptSerializer();
            string serializeStr = javaScriptSerializer.Serialize(userInfoEntity);
            context.Response.Write(serializeStr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}