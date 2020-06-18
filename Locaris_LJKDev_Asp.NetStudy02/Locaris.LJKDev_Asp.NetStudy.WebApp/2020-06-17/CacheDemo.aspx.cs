using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Locaris.LJKDev_Asp.NetStudy.BLL;
using Locaris.LJKDev_Asp.NetStudy.Model;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_17
{
    public partial class CacheDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //缓存：将不经常改动的数据放在缓存里面！
            //分布式缓存 Redis、OA
            //缓存是优化网站的一种手段

            //Cache和Session的区别
            //每个用户都有自己单独的Session对象
            //但是放在Cache中的数据是大家共享的。


            //使用缓存的基本方式：
            //01_判断缓存中是否有数据
            //01_01如果没有数据从数据库中拿
            if (Cache["userInfoList"] == null)
            {
                UserInfoService userInfoService = new UserInfoService();
                List<UserInfoEntity> userInfoList = userInfoService.GetUserInfoList();
                //将数据放在缓存中
                //Cache["userInfoList"] = userInfoList;

                //Cache.Insert()的用法：可以指定过期时间（绝对过期时间、滑动过期时间）
                Cache.Insert("userInfoList", userInfoList, null,
                    DateTime.Now.AddSeconds(5), TimeSpan.Zero,
                    CacheItemPriority.Normal, RemoveCache);

                Response.Write("数据来自数据库！！！！");
                //Cache.Remove("userInfoList"); //移除缓存，数据库缓存的清空！！！
            }
            //01_02如果有数据，从缓存中拿
            else
            {
                List<UserInfoEntity> userInfoList = (List<UserInfoEntity>)Cache["userInfoList"];
                Response.Write("数据来自缓存！！");
            }
        }
        //方法的签名与委托保持一致！！
        protected void RemoveCache(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason== CacheItemRemovedReason.Expired)//移除原因枚举类型！过期了！
            {
                //缓存到期了！
            }
        }
    }
}