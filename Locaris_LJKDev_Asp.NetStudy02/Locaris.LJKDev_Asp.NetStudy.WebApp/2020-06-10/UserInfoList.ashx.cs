using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Common;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_10
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex;
            if (!int.TryParse(context.Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 5;
            UserInfoService userInfoService=new UserInfoService();
            // 01_获取总页数
            int pageCount = userInfoService.GetPageCount(pageSize);               
            // 02_获取当前页的范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            // 03_获取分页数据
            List<UserInfoEntity> userInfoList = userInfoService.GetPageList(pageIndex,pageSize);
            // 04_获取页码条
            string pageBar = PageBarHelper.GetPageBar(pageIndex, pageCount);
            // 05_利用匿名类在实体类的基础上添加一个属性，往客户端多传一些信息
            var m = new                                     //匿名类，在实体类的基础上又添加了一个属性
            {
                myUserInfoList=userInfoList,                                       //匿名类中的属性01_ m_UserInfoList
                myPageBar = pageBar                                                //匿名类中的属性02_ m_PageBar
            };
            // 06_创建JavaScript序列化对象
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            // 07_将匿名类“m”序列化成json字符串
            string strSerialize = javaScriptSerializer.Serialize(m);
            context.Response.Write(strSerialize);

            //不分页：
            //List<UserInfoEntity> userInfoList =userInfoService.GetUserInfoList();
            //JavaScriptSerializer  javaScriptSerializer=new JavaScriptSerializer();//进行序列化
            //string strSerialize = javaScriptSerializer.Serialize(userInfoList);   //将数据序列化成json字符串
            //context.Response.Write(strSerialize);
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