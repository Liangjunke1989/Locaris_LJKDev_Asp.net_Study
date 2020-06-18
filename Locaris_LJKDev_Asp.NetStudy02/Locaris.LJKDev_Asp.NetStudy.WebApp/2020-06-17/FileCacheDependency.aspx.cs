using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Locaris.LJKDev_Asp.NetStudy.WebApp._2020_06_17
{
    public partial class FileCacheDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //01_文件缓存
            string filePath = Request.MapPath("File1.txt");
            if (Cache["fileContent"]==null)
            {
                string fileContent = File.ReadAllText(filePath);
                // 文件缓存依赖:监视依赖关系，对象发生改变时，自动删除缓存的项
                CacheDependency cacheDependency=new CacheDependency(filePath);
                Cache.Insert("fileContent",fileContent,cacheDependency);
                Response.Write("数据来自于文件！！！ 现正在放在缓存中！");
            }
            else
            {
                Response.Write("数据来自于缓存！！！"+Cache["fileContent"]);
            }
            //02_Session的深入
            

        }
    }
}